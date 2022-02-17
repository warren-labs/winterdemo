using System;
using System.Collections.Generic;
using System.Text;

namespace WinterDemo.Domain.Models
{
    public class PlaylistRequest
    {
        public int CustomerId { get; set; }
        public string PlaylistName { get; set; }
    }
}
