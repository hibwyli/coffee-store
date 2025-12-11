using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoAnLapTrinhMang.Models
{
public class KhachHangData
    {
        [JsonPropertyName("maKH")]
        public string MaKH { get; set; }

        [JsonPropertyName("tenKH")]
        public string TenKH { get; set; }

        [JsonPropertyName("SDT")]
        public string SDT { get; set; }

        [JsonPropertyName("diaChi")]
        public string DiaChi { get; set; }
    }
}
