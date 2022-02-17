using System;
using System.Collections.Generic;
using System.Text;

namespace WinterDemo.Domain.Models
{
    public class User
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Genre> Genres { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
