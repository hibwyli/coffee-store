using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
    [FirestoreData]
    public class NhanVien
    {
        [FirestoreDocumentId]
        public string MaNV { get; set; }

        [FirestoreProperty]
        public string TenNV { get; set; }

        [FirestoreProperty]
        public string MatKhau { get; set; }

        [FirestoreProperty]
        public string SDT { get; set; }

        [FirestoreProperty]
        public string DiaChi { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }
    }
}
