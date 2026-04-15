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

// Khởi tạo Admin SDK - cấp quyền quản trị tối cao trên Firebase
admin.initializeApp();

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
    if (req.method !== 'POST') 
        return res.status(405).send({ message: "Method Not Allowed" });

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
        console.error("Error checking email existence:", error);
        return res.status(500).send({ message: "Server error: " + error.message });
    }
});

// Tạo một API endpoint có tên là "generateAndSendOTP" để tạo mã OTP và gửi qua email
exports.generateAndSendOTP = onRequest(async (req, res) => {
    if (req.method !== 'POST') 
        return res.status(405).send({ message: "Method Not Allowed" });

    const { toEmail } = req.body;
    if (!toEmail) 
        return res.status(400).send({ message: "Missing recipient information." });

    try {
        //Server TỰ TẠO mã OTP 6 số ngẫu nhiên (không phải do C# tạo)
        const generatedCode = Math.floor(10000000 + Math.random() * 90000000).toString();

        //Cấu hình trạm phát
        const transporter = nodemailer.createTransport({
            host: "smtp.gmail.com",
            port: 587,
            secure: false, 
            auth: {
                user: emailUserParam.value(),
                pass: emailPassParam.value()
            }
        });

        //Soạn thư
        const mailOptions = {
            from: `"Hệ thống QLCafe" <${emailUserParam.value()}>`,
            to: toEmail,
            subject: 'QLCafe - Password Reset Verification Code',
            text: `Hello, \n\nYour password reset verification code is: ${generatedCode} \n\nNote: This code is valid for 60 seconds only. After this time, it will expire and you will need to request a new one. \n\nPlease do not share this code with anyone. If you did not request this, please ignore this email. \n\nBest regards, \nQLCafe System`
        };

        //Gửi thư
        await transporter.sendMail(mailOptions);
        
        //QUAN TRỌNG: Trả cái mã vừa tạo về cho C# để C# mang lên GUI
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
        const authResponse = await axios.post(
            `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${FIREBASE_API_KEY}`,
            { email: email, password: password, returnSecureToken: true }
        );
        // Nếu lệnh trên không bị lỗi catch, tức là email & pass đã đúng, ta có thể lấy ID Token (nếu cần) để xác thực các lệnh tiếp theo (nếu muốn).
        const idToken = authResponse.data.idToken;
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
        return res.status(200).json({
        token: idToken,
        user: employeeData
    });

    } catch (error) {
        // Bắt lỗi: Nếu email/pass sai, axios sẽ ném lỗi. Ta ném mã 401 về cho WinForms.
        const errorMessage = error.response?.data?.error?.message || error.message;
        console.error("Error:", errorMessage);
        return res.status(401).json({ error: errorMessage });
    }
});

//HÀM XÁC THỰC DÙNG CHUNG: Xác thực Token và trả về thông tin user
async function verifyAndGetUser(req) {
    const authHeader = req.headers.authorization;
    
    if (!authHeader || !authHeader.startsWith('Bearer ')) {
        throw new Error('Missing or invalid authorization header');
    }

    const token = authHeader.split('Bearer ')[1];
    const decodedToken = await admin.auth().verifyIdToken(token);
    const userEmail = decodedToken.email;

    const db = admin.database();
    const snapshot = await db.ref('nhan_vien')
                             .orderByChild('email')
                             .equalTo(userEmail)
                             .once('value');

    if (!snapshot.exists()) {
        throw new Error('User not found in database');
    }

    const data = snapshot.val();
    const employeeId = Object.keys(data)[0];
    const employeeData = data[employeeId];
    employeeData.EmployeeId = employeeId;

    return employeeData; 
}

// Hàm phụ để xác thực Token và kiểm tra vai trò quản lý (Manager Role)
async function verifyManagerRole(req) {
    const authHeader = req.headers.authorization;
    
    // Kiểm tra Token có tồn tại không
    if (!authHeader || !authHeader.startsWith('Bearer ')) {
        throw new Error('Missing or invalid authorization header');
    }

    const token = authHeader.split('Bearer ')[1];

    // Giải mã Token
    const decodedToken = await admin.auth().verifyIdToken(token);
    const userEmail = decodedToken.email; // Lấy email từ token

    // Truy vấn Database để tìm thông tin chi tiết của nhân viên này
    const db = admin.database();
    const snapshot = await db.ref('nhan_vien')
                             .orderByChild('email')
                             .equalTo(userEmail)
                             .once('value');

    if (!snapshot.exists()) {
        throw new Error('User not found in database');
    }

    const data = snapshot.val();
    const employeeId = Object.keys(data)[0];
    const employeeData = data[employeeId];

    // KIỂM TRA QUYỀN (Role)
    const userRole = employeeData.vai_tro; 

    if (userRole !== 'manager' && userRole !== 'admin') {
        // Ném ra lỗi NẾU KHÔNG PHẢI LÀ QUẢN LÝ
        throw new Error('Permission denied. Manager role is required.'); 
    }

    // Nếu qua được ải này, trả về thông tin người dùng
    return employeeData; 
}

//Tao một API endpoint có tên là "getAllEmployees" để trả về danh sách tất cả nhân viên (dữ liệu từ Realtime Database)
exports.getAllEmployees = onRequest(async (req, res) => {
    if (req.method !== "GET") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    try {
        // Xác thực người gọi API là ai (Bất kỳ ai có token hợp lệ đều qua được)
        const requestUser = await verifyAndGetUser(req);
        
        // Lấy toàn bộ dữ liệu từ node 'nhan_vien'
        const snapshot = await admin.database().ref('nhan_vien').once('value');
        const allEmployees = snapshot.val() || {};

        // Xử lý phân quyền trả về dữ liệu
        const uoserRle = (requestUser.vai_tro || "").toLowerCase();

        if (userRole === 'manager' || userRole === 'admin') {
            // Manager/Admin: Trả về toàn bộ danh sách
            return res.status(200).send(allEmployees);
        } else {
            // Staff (Nhân viên): Lọc chỉ lấy những người là Manager hoặc Admin
            const managersOnly = {};
            
            Object.keys(allEmployees).forEach(key => {
                const emp = allEmployees[key];
                const targetRole = (emp.vai_tro || "").toLowerCase();
                if (targetRole === 'manager') {
                    managersOnly[key] = emp;
                }
            });

            return res.status(200).send(managersOnly);
        }

    } catch (error) {
        console.error("Auth/Query Error:", error.message);
        return res.status(403).send({ error: "Access Denied: " + error.message });
    }
});

// Tạo một API endpoint có tên là "addEmployee" để thêm nhân viên mới vào Realtime Database
exports.addEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    // Biến tạm để theo dõi tài khoản Auth vừa tạo (dùng cho việc rollback)
    let createdUser = null;

    try {
        // Kiểm tra xem người gọi API này có phải là Manager không
        await verifyManagerRole(req);

        const employeeData = req.body;
        
        // Hứng Email và Password (Xử lý linh hoạt việc C# gửi lên chữ hoa hay chữ thường)
        const email = (employeeData.email || "").trim(); 
        const password = (employeeData.Password || "").trim(); 
        const fullName = (employeeData.ho_ten || "").trim();

        if (!email || !password) {
            console.log("Error:", employeeData);
            return res.status(400).send({ error: "Email and Password are required!" });
        }
        // TẠO TÀI KHOẢN ĐĂNG NHẬP TRÊN FIREBASE AUTHENTICATION
        // Hàm này sẽ tự động ném lỗi nếu Email đã tồn tại hoặc Password quá yếu
        createdUser = await admin.auth().createUser({
            email: email,
            password: password,
            displayName: fullName
        });
        // TẠO MÃ NHÂN VIÊN VÀ LƯU VÀO REALTIME DATABASE
        const ref = admin.database().ref('nhan_vien');
        const snapshot = await ref.once('value');
        const employees = snapshot.val() || {};

        let maxIdNum = 0;
        Object.keys(employees).forEach(key => {
            const match = key.match(/\d+/); 
            if (match) {
                const num = parseInt(match[0]);
                if (num > maxIdNum) maxIdNum = num;
            }
        });

        const nextId = `nv_${(maxIdNum + 1).toString().padStart(3, '0')}`;
        
        // Gán thêm thông tin hệ thống
        employeeData.trang_thai = "active"; // Ép giá trị này vào field trang_thai
        if (!employeeData.ngay_vao_lam) {
            const today = new Date();
            const dd = String(today.getDate()).padStart(2, '0');
            const mm = String(today.getMonth() + 1).padStart(2, '0');
            const yyyy = today.getFullYear();
            employeeData.ngay_vao_lam = `${dd}/${mm}/${yyyy}`;
        }
        
        // Liên kết với tài khoản Auth (Rất hữu ích sau này nếu muốn khóa/xóa tài khoản)
        employeeData.AuthUid = createdUser.uid; 

        // BẢO MẬT TỐI ĐA: Xóa bỏ thuộc tính Password trước khi lưu xuống Database
        // Vì Firebase Auth đã giữ password được mã hóa rồi, DB không nên chứa pass thô.
        delete employeeData.Password;
        delete employeeData.password;

        // Lưu toàn bộ thông tin (đã giấu pass) xuống Database
        await ref.child(nextId).set(employeeData);

        return res.status(200).send({ 
            success: true, 
            employeeId: nextId, 
            message: "Employee account and profile created successfully!" 
        });

    } catch (error) {
        console.error("Add Employee Error:", error.message);
        // CƠ CHẾ ROLLBACK (HOÀN TÁC) CHI TIẾT: Nếu đã tạo tài khoản Auth nhưng lỗi xảy ra khi lưu Database, ta sẽ xóa tài khoản Auth vừa tạo để tránh "tài khoản ma" không có profile.
        if (createdUser) {
            // Nếu đã lỡ tạo Auth mà DB bị lỗi -> Phải xóa Auth ngay để tránh tài khoản ma
            await admin.auth().deleteUser(createdUser.uid);
            console.log(`Undo: Delete Auth account ${createdUser.email} do lỗi lưu Database.`);
        }
        // Trả về lỗi cụ thể cho C#
        let friendlyMessage = error.message;
        if (error.code === 'auth/email-already-exists') {
            friendlyMessage = "This email address is already registered to another staff member.";
        }
        // Nếu lỗi xảy ra (ví dụ: Email đã được sử dụng), trả về ngay cho C# hiển thị
        return res.status(400).send({ error: friendlyMessage });
    }
});

// Tạo một API endpoint có tên là "updateEmployee" để cập nhật thông tin nhân viên (trừ email và password) trong Realtime Database
exports.updateEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send({ message: "Method Not Allowed" });

    try {
        // BẢO MẬT: Chỉ Manager có token hợp lệ mới qua được ải này
        await verifyManagerRole(req);

        const { employeeId, updateData } = req.body;

        if (!employeeId || !updateData) {
            return res.status(400).send({ error: "Missing employeeId or updateData" });
        }

        // Không cho phép sửa đổi những trường cốt lõi qua API này
        delete updateData.AuthUid; 
        delete updateData.email; // Đổi email phức tạp hơn, cần admin.auth().updateUser

        // Cập nhật vào Realtime Database
        await admin.database().ref(`nhan_vien/${employeeId}`).update(updateData);

        return res.status(200).send({ success: true, message: "Cập nhật hồ sơ thành công!" });
    } catch (error) {
        console.error("Update Error:", error.message);
        return res.status(403).send({ error: "Access Denied: " + error.message });
    }
});

// Tạo một API endpoint có tên là "lockEmployee" để khóa tài khoản nhân viên trong Realtime Database
exports.lockEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send({ message: "Method Not Allowed" });

    try {
        // BẢO MẬT: Phân quyền Manager
        await verifyManagerRole(req);

        const { employeeId, authUid } = req.body;

        if (!employeeId || !authUid) {
            return res.status(400).send({ error: "Missing employeeId or authUid" });
        }

        // 1. Cập nhật trạng thái trong Database thành "inactive"
        await admin.database().ref(`nhan_vien/${employeeId}`).update({
            trang_thai: "inactive"
        });

        //Disable tài khoản trên Firebase Authentication (Người này không thể Login được nữa)
        await admin.auth().updateUser(authUid, {
            disabled: true
        });

        return res.status(200).send({ success: true, message: "Staff account has been locked" });
    } catch (error) {
        console.error("Lock Error:", error.message);
        return res.status(403).send({ error: "Access Denied: " + error.message });
    }
});
//Function Lưu tin nhắn chat vào Realtime Database
exports.saveChatMessage = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");
    try {
        const requestUser = await verifyAndGetUser(req);
        const { roomId, chatData } = req.body;

        // Lấy thời gian chuẩn từ Server để làm khóa (ID)
        const serverTime = Date.now();
        
        // Đảm bảo chatData có đủ các trường mà Node.js/Firebase mong muốn
        // Cần khớp với các thuộc tính [JsonPropertyName] bên C#
        chatData.thoi_gian = serverTime; 

        const msgId = `msg_${serverTime}`;
        await admin.database().ref(`tin_nhan/${roomId}/${msgId}`).set(chatData);
        
        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
// Function Lấy lịch sử chat từ Realtime Database dựa trên roomId
exports.getChatHistory = onRequest(async (req, res) => {
    const { roomId } = req.query;
    try {
        const requestUser = await verifyAndGetUser(req);
        const snapshot = await admin.database().ref(`tin_nhan/${roomId}`)
                                    .orderByChild("thoi_gian")
                                    .once("value");
        const history = [];
        snapshot.forEach((child) => {
            history.push(child.val());
        });
        return res.status(200).send(history);
    } catch (error) {
        console.error("Get Chat History Error:", error.message);
        return res.status(500).send({ error: error.message });
    }
});