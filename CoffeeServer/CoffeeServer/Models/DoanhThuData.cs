using System.Text.Json.Serialization;

namespace CoffeeServer.Models
{
    public class DoanhThuData
    {
        [JsonPropertyName("startDate")]
        public string StartDate { get; set; } // ISO format "yyyy-MM-dd"
        [JsonPropertyName("endDate")]

        public string EndDate { get; set; }   // ISO format "yyyy-MM-dd"
        [JsonPropertyName("execDate")]

        public string Date { get; set; }      // cho tính doanh thu 1 ngày
    }
}
