using Google.Cloud.Firestore;
using System;

namespace DoAnLapTrinhMang.Models
{
    [FirestoreData]
    public class ResetPasswordToken
    {
        [FirestoreDocumentId]
        public string Id { get; set; }  // ID tài liệu trong Firestore (tự sinh hoặc chính token)

        [FirestoreProperty]
        public string Email { get; set; }  // Liên kết với user cần reset mật khẩu

        [FirestoreProperty]
        public string Token { get; set; }  // Mã token gửi qua email

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [FirestoreProperty]
        public DateTime ExpiresAt { get; set; }  // Hạn dùng của token (ví dụ 15 phút)

        [FirestoreProperty]
        public bool IsUsed { get; set; } = false;  // Đánh dấu nếu token đã dùng rồi
    }
}
