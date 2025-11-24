using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
    [FirestoreData]
    public class DoUong
    {
        [FirestoreDocumentId]
        public string MaDU { get; set; }

        [FirestoreProperty]
        public string TenDU { get; set; }

        [FirestoreProperty]
        public string MaLoai { get; set; }

        [FirestoreProperty]
        public double DonGia { get; set; }  

        [FirestoreProperty]
        public string HinhAnh { get; set; }
    }
}
