using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json.Serialization;

namespace CoffeeServer.Models
{
    public class RequestModel
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }   // "LOGIN" hoặc "REGISTER"

        [JsonPropertyName("data")]
        public UserData Data { get; set; }   // Thông tin người dùng
        [JsonPropertyName("collectionName")]
        public string CollectionName{ get; set; }

        [JsonPropertyName("DuData")]
        public  DoUongData DuData { get; set; }
    }
}
