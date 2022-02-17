using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WinterDemo.Domain.Models
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
