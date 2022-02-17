using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinterDemo.Domain.Models;

namespace WinterDemo.Domain.Interfaces
{
    public interface IPlaylistProvider
    {
        Task<List<Playlist>> GetCustomerPlaylistsAsync(int customerId);
        Task<List<PlaylistTrack>> GetPlaylistTracksAsync(int playlistId);
        Task<List<Track>> GetPlaylistTrackDetailsAsync(int trackId);
        Task<List<Track>> GetAllPlaylistTrackDetailsAsync(int playlistId);
        Task<List<Genre>> GetPlaylistGenresAsync(int customerId);
        Task<bool> AddCustomerPlaylistAsync(PlaylistRequest playlist);
    }
}
