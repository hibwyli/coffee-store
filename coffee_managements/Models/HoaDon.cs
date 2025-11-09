using Google.Cloud.Firestore;
using System;

namespace DoAnLapTrinhMang.Models
{
    [FirestoreData]
    public class HoaDon
    {
        [FirestoreDocumentId]
        public string MaHD { get; set; }

        [FirestoreProperty]
        public DateTime NgayLap { get; set; }

        [FirestoreProperty]
        public string MaNV { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; }

        [FirestoreProperty]
        public string MaBan { get; set; }

        [FirestoreProperty]
        public double TongTien { get; set; }

        [FirestoreProperty]
        public string TrangThai { get; set; }
    }
}
