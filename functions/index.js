// Import thư viện Firebase Functions và Firebase Admin
const {onRequest} = require("firebase-functions/v2/https");
const admin = require("firebase-admin");
const axios = require('axios'); // Thư viện HTTP client để gửi yêu cầu từ C# (nếu cần)
const nodemailer = require('nodemailer'); // Thư viện để gửi email (nếu cần)
//DÒNG NÀY VÀO ĐỂ ĐỌC FILE .ENV CHUẨN XÁC:
const { defineString } = require('firebase-functions/params');
// Định nghĩa các biến môi trường (Environment Variables) để lưu trữ thông tin nhạy cảm
const apiKeyParam = defineString('API_KEY');
const appSecretParam = defineString('APP_SECRET_KEY');
// Đọc thông tin email từ biến môi trường (nếu cần gửi email)
const emailUserParam = defineString('EMAIL_USER');
const emailPassParam = defineString('EMAIL_PASS');
const managerSecretParam = defineString('MANAGER_SECRET_KEY');

// Khởi tạo Admin SDK - cấp quyền quản trị tối cao trên Firebase
admin.initializeApp();

const authorize = (req) => req.headers['x-manager-secret'] === managerSecretParam.value();
/**
 * Hàm updateUserPassword: Được gọi từ WinForms để đổi mật khẩu
 * req: Đối tượng chứa dữ liệu gửi lên (Request)
 * res: Đối tượng dùng để phản hồi kết quả về (Response)
 */
exports.updateUserPassword = onRequest(async (req, res) => {
  // 1. Kiểm tra method: Chỉ nhận POST (để bảo mật dữ liệu)
  if (req.method !== "POST") {
    return res.status(405).send("Method Not Allowed");
  }
  // 2. Lấy dữ liệu từ body của yêu cầu
  const {email, newPassword, secretKey} = req.body;

  // 3. Khai báo mã bí mật (Secret Key) - mật mã giữa App và Server
  // CHÚ Ý: Chuỗi này phải khớp hoàn toàn với C#
  const MY_PRIVATE_KEY = appSecretParam.value();
  // 4. Xác thực mã bí mật: Từ chối nếu không khớp (Lỗi 403)
  if (secretKey !== MY_PRIVATE_KEY) {
    // Đã bọc trong { message: ... }
    return res.status(403).send({ message: "Unauthorized: Invalid Secret Key" });
  }
  try {
    // 5. Tìm thông tin người dùng qua Email để lấy UID
    const userRecord = await admin.auth().getUserByEmail(email);

    // 6. Ghi đè mật khẩu mới vào UID vừa tìm thấy
    await admin.auth().updateUser(userRecord.uid, {
      password: newPassword,
    });

    // 7. Trả về mã 200 và thông báo thành công
    return res.status(200).send({message: "Password updated successfully"});
  } catch (error) {
    // 8. Bắt lỗi (sai email, pass yếu...) và trả về lỗi 500
    console.error("Error:", errorMessage);
    return res.status(500).send({error: error.message});
  }
});

// Tạo một API endpoint có tên là "sendVerificationEmail" để gửi mã xác nhận qua email
exports.sendVerificationEmail = onRequest(async (req, res) => {
    if (req.method !== 'POST') {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    const { toEmail, code } = req.body;

    if (!toEmail || !code) {
        return res.status(400).send({ message: "Missing recipient information or verification code." });
    }

    try {
        // Cấu hình trạm phát SMTP của Google
        const transporter = nodemailer.createTransport({
            host: "smtp.gmail.com",
            port: 587,
            secure: false, // false đối với port 587 (nó sẽ tự nâng cấp lên TLS)
            auth: {
                user: emailUserParam.value(),
                pass: emailPassParam.value()
          }
        });

        // Thiết lập nội dung thư gồm người gửi, người nhận, tiêu đề và nội dung văn bản
        const mailOptions = {
            from: `"Hệ thống QLCafe" <${emailUserParam.value()}>`,
            to: toEmail,
            subject: 'QLCafe - Password Reset Verification Code',
            text: `Hello, \n\nYour password reset verification code is: ${code} \n\nNote: This code is valid for 60 seconds only. After this time, it will expire and you will need to request a new one. \n\nPlease do not share this code with anyone. If you did not request this, please ignore this email. \n\nBest regards, \nQLCafe System`
        };

        // Bắt đầu gửi
        await transporter.sendMail(mailOptions);
        
        return res.status(200).send({ message: "Verification code has been sent successfully!" });

    } catch (error) {
        console.error("SMTP mail delivery error:", error);
        return res.status(500).send({ message: "Server error when sending email: " + error.message });
    }
});

// Tạo một API endpoint có tên là "checkEmailExists" để kiểm tra xem email đã tồn tại trong Firebase Auth chưa
exports.checkEmailExists = onRequest(async (req, res) => {
    if (req.method !== 'POST') return res.status(405).send({ message: "Method Not Allowed" });

    const { email } = req.body;
    if (!email) return res.status(400).send({ message: "Missing email." });

    try {
        // Dùng quyền admin hỏi Firebase xem có user này không
        await admin.auth().getUserByEmail(email);
        
        // Nếu không có lỗi -> Email tồn tại
        return res.status(200).send({ exists: true, message: "Valid email address." });
    } catch (error) {
        if (error.code === 'auth/user-not-found') {
            return res.status(404).send({ exists: false, message: "Email address not found." });
        }
        return res.status(500).send({ message: "Server error: " + error.message });
    }
});

// Tạo một API endpoint có tên là "generateAndSendOTP" để tạo mã OTP và gửi qua email
exports.generateAndSendOTP = onRequest(async (req, res) => {
    if (req.method !== 'POST') return res.status(405).send({ message: "Method Not Allowed" });

    const { toEmail } = req.body;
    if (!toEmail) return res.status(400).send({ message: "Missing recipient information." });

    try {
        // 1. Server TỰ TẠO mã OTP 6 số ngẫu nhiên (không phải do C# tạo)
        const generatedCode = Math.floor(10000000 + Math.random() * 90000000).toString();

        // 2. Cấu hình trạm phát
        const transporter = nodemailer.createTransport({
            host: "smtp.gmail.com",
            port: 587,
            secure: false, 
            auth: {
                user: emailUserParam.value(),
                pass: emailPassParam.value()
            }
        });

        // 3. Soạn thư
        const mailOptions = {
            from: `"Hệ thống QLCafe" <${emailUserParam.value()}>`,
            to: toEmail,
            subject: 'QLCafe - Password Reset Verification Code',
            text: `Hello, \n\nYour password reset verification code is: ${generatedCode} \n\nNote: This code is valid for 60 seconds only. After this time, it will expire and you will need to request a new one. \n\nPlease do not share this code with anyone. If you did not request this, please ignore this email. \n\nBest regards, \nQLCafe System`
        };

        // 4. Gửi thư
        await transporter.sendMail(mailOptions);
        
        // 5. QUAN TRỌNG: Trả cái mã vừa tạo về cho C# để C# mang lên GUI
        return res.status(200).send({ 
            message: "Verification code has been sent successfully!", 
            code: generatedCode 
        });

    } catch (error) {
        console.error("SMTP mail delivery error:", error);
        return res.status(500).send({ message: "Server error when sending email: " + error.message });
    }
});

// Tạo một API endpoint có tên là "loginEmployee"
exports.loginEmployee = onRequest(async (req, res) => {
    // Ép buộc client WinForms phải dùng phương thức POST để gửi dữ liệu bảo mật
    if (req.method !== 'POST') {
        return res.status(405).send('Method Not Allowed');
    }

    // Lấy email và password do WinForms (AuthDAL) gửi lên
    const { email, password } = req.body;

    // Giấu Web API Key: Thay vì để ở AppConfig (C#), ta lưu nó trong biến môi trường của Firebase Server.
    // Dùng .env:
    const FIREBASE_API_KEY = apiKeyParam.value();

    try {
        // Admin SDK không có hàm đăng nhập bằng mật khẩu, nên ta gọi thẳng REST API của Firebase Auth.
        await axios.post(
            `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${FIREBASE_API_KEY}`,
            { email: email, password: password, returnSecureToken: true }
        );
        // Nếu lệnh trên không bị lỗi catch, tức là email & pass đã đúng.

        // Thay vì WinForms biết bảng "nhan_vien" và query OrderBy, giờ server Node.js sẽ làm.
        const db = admin.database();
        
        // Đoạn này thay thế chính xác lệnh: firebaseClient.Child("nhan_vien").OrderBy("email").EqualTo(email)
        const snapshot = await db.ref('nhan_vien')
                                 .orderByChild('email')
                                 .equalTo(email)
                                 .once('value');

        // Nếu query không ra kết quả nào
        if (!snapshot.exists()) {
            return res.status(404).json({ message: "Employee data not found in database." });
        }

        //LẤY DỮ LIỆU VÀ TRẢ VỀ ---
        const data = snapshot.val(); // Lấy toàn bộ kết quả tìm được
        
        // Vì truy vấn OrderBy trả về một danh sách (dù chỉ có 1 kết quả), 
        // ta lấy Key (ID) của phần tử đầu tiên (VD: "nv_001")
        const employeeId = Object.keys(data)[0]; 
        
        // Lấy object chứa thông tin nhân viên tương ứng với ID đó
        const employeeData = data[employeeId];

        // Gán thêm cái ID vào object giống như dòng: loggedInUser.EmployeeId = firstResult.Key; bên C#
        employeeData.EmployeeId = employeeId;

        // Trả kết quả JSON về cho C#
        return res.status(200).json(employeeData);

    } catch (error) {
        // Bắt lỗi: Nếu email/pass sai, axios sẽ ném lỗi. Ta ném mã 401 về cho WinForms.
        const errorMessage = error.response?.data?.error?.message || error.message;
        console.error("Error:", errorMessage);
        return res.status(401).json({ error: errorMessage });
    }
});

//Tao một API endpoint có tên là "getAllEmployees" để trả về danh sách tất cả nhân viên (dữ liệu từ Realtime Database)
exports.getAllEmployees = onRequest(async (req, res) => {
    // Chỉ nhận GET để truy vấn
    if (req.method !== "GET") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    // Kiểm tra Secret Key (Mã bí mật từ App.config gửi qua Header)
    if (!authorize(req)) 
        return res.status(403).send({ message: "Unauthorized: Invalid Secret Key" });

    try {
        const snapshot = await admin.database().ref('nhan_vien').once('value');
        const data = snapshot.val();
        // Trả về dữ liệu (hoặc object rỗng nếu chưa có nhân viên)
        return res.status(200).send(data || {});
    } catch (error) {
        console.error("Query Error:", error.message);
        return res.status(500).send({ error: error.message });
    }
});

// Tạo một API endpoint có tên là "addEmployee" để thêm nhân viên mới vào Realtime Database
exports.addEmployee = onRequest(async (req, res) => {
    // Chỉ nhận POST để ghi dữ liệu
    if (req.method !== "POST") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    if (!authorize(req)) 
        return res.status(403).send({ message: "Unauthorized: Invalid Secret Key" });

    const employeeData = req.body;

    try {
        const ref = admin.database().ref('nhan_vien');
        const snapshot = await ref.once('value');
        const employees = snapshot.val() || {};

        // --- LOGIC TỰ TẠO MÃ NHÂN VIÊN (STT) ---
        let maxIdNum = 0;
        Object.keys(employees).forEach(key => {
            const match = key.match(/\d+/); // Tìm phần số trong chuỗi 'nv_001'
            if (match) {
                const num = parseInt(match[0]);
                if (num > maxIdNum) maxIdNum = num;
            }
        });

        // Tạo mã mới định dạng nv_xxx (VD: nv_005)
        const nextId = `nv_${(maxIdNum + 1).toString().padStart(3, '0')}`;
        
        // Gán thông tin hệ thống tự tạo
        employeeData.EmployeeId = nextId;
        employeeData.Status = "active";
        employeeData.CreatedAt = new Date().toISOString();

        // Lưu vào Realtime Database
        await ref.child(nextId).set(employeeData);

        return res.status(200).send({ 
            success: true, 
            employeeId: nextId, 
            message: "Employee added successfully!" 
        });

    } catch (error) {
        console.error("Add Employee Error:", error.message);
        return res.status(500).send({ error: error.message });
    }
});