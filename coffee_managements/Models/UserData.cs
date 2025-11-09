using System.Text.Json.Serialization;


namespace DoAnLapTrinhMang.Models
{
    public class UserData
    {
        [JsonPropertyName("tenTaiKhoan")]
        public string TenTaiKhoan { get; set; }

        [JsonPropertyName("matKhau")]
        public string MatKhau { get; set; }

        [JsonPropertyName("xacNhanMK")]
        public string XacNhanMK { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("quyen")]
        public string Quyen { get; set; }
    }
}
