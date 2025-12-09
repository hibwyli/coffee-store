using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoAnLapTrinhMang.Models
{
    public class BanData
    {
        [JsonPropertyName("maBan")]
        public string MaBan { get; set; }

        [JsonPropertyName("soBan")]
        public int SoBan { get; set; }

        [JsonPropertyName("sucChua")]
        public int SucChua { get; set; }
    }
}
