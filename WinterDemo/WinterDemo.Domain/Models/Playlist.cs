using System;
using System.Collections.Generic;
using System.Text;

namespace WinterDemo.Domain.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
    }
}
