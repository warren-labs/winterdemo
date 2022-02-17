using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WinterDemo.Domain.Models
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
