using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
    [FirestoreData]
    public class Ban
    {
        [FirestoreDocumentId]
        public string MaBan { get; set; }

        [FirestoreProperty]
        public int SucChua { get; set; }

        [FirestoreProperty]
        public string TrangThai { get; set; }
    }
}
