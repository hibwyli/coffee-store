using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;
namespace CoffeeServer.Models
{
    public class DoUongData
    {
        public DoUongData() { }

        [FirestoreDocumentId]
        [JsonPropertyName("maDU")]
        public string MaDU { get; set; }

        [FirestoreProperty("tenDoUong")]
        [JsonPropertyName("tenDoUong")]
        public string TenDU { get; set; }

        [FirestoreProperty("maLoaiDU")]
        [JsonPropertyName("maLoaiDU")]
        public string MaLoai { get; set; }

        [FirestoreProperty("donGia")]
        [JsonPropertyName("donGia")]
        public int DonGia { get; set; }
    }
}
