using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace CoffeeServer.Models
{
public class KhachHangData
    {
        public KhachHangData() { }

        [FirestoreDocumentId]
        [JsonPropertyName("maKH")]
        public string MaKH { get; set; }

        [FirestoreProperty("tenKH")]
        [JsonPropertyName("tenKH")]
        public string TenKH { get; set; }

        [FirestoreProperty("SDT")]
        [JsonPropertyName("SDT")]
        public string SDT { get; set; }

        [FirestoreProperty("diaChi")]
        [JsonPropertyName("diaChi")]
        public string DiaChi{ get; set; }
    }
}
