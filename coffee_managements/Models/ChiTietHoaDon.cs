using Google.Cloud.Firestore;

namespace DoAnLapTrinhMang.Models
{
    [FirestoreData]
    public class ChiTietHoaDon
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public string MaHD { get; set; }

        [FirestoreProperty]
        public string MaDU { get; set; }

        [FirestoreProperty]
        public int SoLuong { get; set; }

        [FirestoreProperty]
        public double DonGia { get; set; }

        [FirestoreProperty]
        public double ThanhTien { get; set; }
    }
}
