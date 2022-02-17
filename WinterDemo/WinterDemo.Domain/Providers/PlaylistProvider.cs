using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterDemo.Domain.Contexts;
using WinterDemo.Domain.Interfaces;
using WinterDemo.Domain.Models;

namespace WinterDemo.Domain.Providers
{
    public class PlaylistProvider : IPlaylistProvider, IDisposable
    {
        private bool disposedValue;
        private ChinookContext _context;
        private ILogger<PlaylistProvider> _logger;

        public PlaylistProvider(ChinookContext context, ILogger<PlaylistProvider> logger)
        {
            // null checks for injection
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<Playlist>> GetCustomerPlaylistsAsync(int customerId)
        {
            return await _context.Playlist.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<PlaylistTrack>> GetPlaylistTracksAsync(int playlistId)
        {
            return await _context.PlaylistTrack.Where(x => x.PlaylistId == playlistId).ToListAsync();
        }

        public async Task<List<Track>> GetPlaylistTrackDetailsAsync(int trackId)
        {
            return await _context.Track.Where(x => x.TrackId == trackId).ToListAsync();
        }

        public async Task<List<Track>> GetAllPlaylistTrackDetailsAsync(int playlistId)
        {
            // get the list to track ids
            List<PlaylistTrack> playlistTracks = new List<PlaylistTrack>();
            playlistTracks.AddRange(await GetPlaylistTracksAsync(playlistId));

            // get all the tracks on my playlist
            List<Track> tracks = new List<Track>();
            playlistTracks.ForEach(async track =>
            {
                tracks.AddRange(await _context.Track.Where(x => x.TrackId == track.TrackId).ToListAsync());
            });

            return tracks.Distinct().ToList();
        }

        public async Task<List<Genre>> GetPlaylistGenresAsync(int customerId)
        {
            // get my playlists
            List<Playlist> playlists = await GetCustomerPlaylistsAsync(customerId);

            // get the list to track ids
            List<PlaylistTrack> playlistTracks = new List<PlaylistTrack>();
            playlists.ForEach(async x => {
                playlistTracks.AddRange(await GetPlaylistTracksAsync(x.PlaylistId));
            });

            // get all the tracks on my playlist
            List<Track> tracks = new List<Track>();
            playlistTracks.ForEach(async x => {
                tracks.AddRange(await GetPlaylistTrackDetailsAsync(x.TrackId));
            });

            // get all the genres on my playlist
            List<Genre> genres = new List<Genre>();
            tracks.ForEach(async track => {
                genres.AddRange(await _context.Genre.Where(x => x.GenreId == track.GenreId).ToListAsync());
            });

            return genres.Distinct().ToList();
        }

        public async Task<bool> AddCustomerPlaylistAsync(PlaylistRequest playlist)
        {
            try
            {
                // check for null
                _ = playlist ?? throw new ArgumentNullException(nameof(playlist));

                // map and add to context
                _context.Playlist.Add(new Playlist { 
                    CustomerId = playlist.CustomerId,
                    Name = playlist.PlaylistName
                });

                // save changes
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding playlist name: [{playlist.PlaylistName}]");
                return false;
            }
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CustomerProvider()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
