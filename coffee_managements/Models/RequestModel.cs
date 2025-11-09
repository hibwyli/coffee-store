using DoAnLapTrinhMang.Models;
using System.Text.Json.Serialization;

namespace CoffeeServer.Models
{
    public class RequestModel
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }   // "LOGIN" hoặc "REGISTER"

        [JsonPropertyName("data")]
        public UserData Data { get; set; }   // Thông tin người dùng
    }
}
