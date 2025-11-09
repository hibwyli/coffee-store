using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
    [FirestoreData]
    public class LoaiDoUong
    {
        [FirestoreDocumentId]
        public string MaLoai { get; set; }

        [FirestoreProperty]
        public string TenLoai { get; set; }
    }
}
