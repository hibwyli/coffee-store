using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CoffeeServer.Models
{
    public class BanData
    {
        public BanData() { }

        [FirestoreDocumentId]
        [JsonPropertyName("maBan")]
        public string MaBan { get; set; }

        [FirestoreProperty("soBan")]
        [JsonPropertyName("soBan")]
        public int SoBan { get; set; }

        [FirestoreProperty("sucChua")]
        [JsonPropertyName("sucChua")]
        public int SucChua { get; set; }
    }
}
