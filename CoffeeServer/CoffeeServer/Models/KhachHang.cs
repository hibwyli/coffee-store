using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
    [FirestoreData]
    public class KhachHang
    {
        [FirestoreDocumentId]
        public string MaKH { get; set; }

        [FirestoreProperty]
        public string TenKH { get; set; }

        [FirestoreProperty]
        public string SDT { get; set; }

        [FirestoreProperty]
        public string DiaChi { get; set; }

        [FirestoreProperty]
        public string MatKhau { get; set; } // dùng cho login
        [FirestoreProperty]
        public string Email { get; set; } // dùng cho login
    }
}
