using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoAnLapTrinhMang.Models
{
    public class DoUongData
    {
        [JsonPropertyName("maDU")]
        public string MaDU { get; set; }

        [JsonPropertyName("tenDoUong")]
        public string TenDU { get; set; }

        [JsonPropertyName("maLoaiDU")]
        public string MaLoai { get; set; }

        [JsonPropertyName("donGia")]
        public decimal DonGia { get; set; }
    }
}
