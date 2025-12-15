using Google.Cloud.Firestore;
using System.Text.Json.Serialization;
namespace DoAnLapTrinhMang.Models
{

    [FirestoreData]
    public class HoaDonItem
    {
        [FirestoreProperty]
        [JsonPropertyName("MaDoUong")]
        public string MaDoUong { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("TenDoUong")]
        public string TenDoUong { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("SoLuong")]
        public int SoLuong { get; set; }

        [FirestoreProperty]
        [JsonPropertyName("DonGia")]
        public int DonGia { get; set; }
    }

}