using CoffeeServer.Models;
using Google.Cloud.Firestore;
using System.Text.Json.Serialization;

[FirestoreData]
public class HoaDon
{
    [FirestoreDocumentId]
    [JsonPropertyName("MaHD")]
    public string MaHD { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("NgayLap")]
    public DateTime NgayLap { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("TenNV")]
    public string TenNV { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("MaKH")]
    public string MaKH { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("MaBan")]
    public string MaBan { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("TongTien")]
    public double TongTien { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("TrangThai")]
    public string TrangThai { get; set; }

    [FirestoreProperty]
    [JsonPropertyName("Items")]
    public List<HoaDonItem> Items { get; set; } = new List<HoaDonItem>();
}
