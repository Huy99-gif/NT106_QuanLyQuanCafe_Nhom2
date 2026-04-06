// Import thư viện Firebase Functions và Firebase Admin
const {onRequest} = require("firebase-functions/v2/https");
const admin = require("firebase-admin");

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
  const MY_PRIVATE_KEY = "Chuoi_Bi_Mat_Cua_Ban_Vua_Tao";

  // 4. Xác thực mã bí mật: Từ chối nếu không khớp (Lỗi 403)
  if (secretKey !== MY_PRIVATE_KEY) {
    return res.status(403).send("Unauthorized: Invalid Secret Key");
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
    return res.status(500).send({error: error.message});
  }
});