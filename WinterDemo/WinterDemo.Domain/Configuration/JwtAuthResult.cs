using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WinterDemo.Domain.Configuration
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
