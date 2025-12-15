using Google.Cloud.Firestore;
using System.Text.Json.Serialization;

namespace CoffeeServer.Models
{
    public class HoaDonData
    {
        [JsonPropertyName("NgayLap")]
        public DateTime NgayLap { get; set; }

        [JsonPropertyName("MaKH")]
        public string MaKH { get; set; }

        [JsonPropertyName("MaBan")]
        public string MaBan { get; set; }

        [JsonPropertyName("TongTien")]
        public double TongTien { get; set; }

        [JsonPropertyName("TrangThai")]
        public string TrangThai { get; set; }
        [JsonPropertyName("MaHD")]

        public string MaHD { get; set; }

    }
}
