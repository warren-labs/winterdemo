using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinterDemo.Domain.Contexts;
using WinterDemo.Domain.Models;
using WinterDemo.Domain.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WinterDemo.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly ChinookContext _context;
        private ILogger<PlaylistProvider> _logger;

        public PlaylistController(ChinookContext context, ILogger<PlaylistProvider> logger)
        {
            // null checks for injection
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("customer/{customerId}/genres")]
        public async Task<List<Genre>> GetCustomerPlaylistsGenresAsync(int customerId)
        {
            List<Genre> genres = null;

            using (PlaylistProvider provider = new PlaylistProvider(_context, _logger))
            {
                genres = await provider.GetPlaylistGenresAsync(customerId);
            }

            return genres;
        }

        [HttpGet("customer/{customerId}/playlists")]
        public async Task<List<Playlist>> GetCustomerPlaylistsAsync(int customerId)
        {
            List<Playlist> playlists = null;

            using (PlaylistProvider provider = new PlaylistProvider(_context, _logger))
            {
                playlists = await provider.GetCustomerPlaylistsAsync(customerId);
            }

            return playlists;
        }

        [HttpGet("customer/{customerId}/tracks/{playlistId}")]
        public async Task<List<PlaylistTrack>> GetPlaylistTracksAsync(int customerId, int playlistId)
        {
            List<PlaylistTrack> playlists = null;

            using (PlaylistProvider provider = new PlaylistProvider(_context, _logger))
            {
                playlists = await provider.GetPlaylistTracksAsync(playlistId);
            }

            return playlists;
        }

        [HttpGet("customer/{customerId}/playlist/{playlistId}/tracks")]
        public async Task<List<Track>> GetAllPlaylistTrackDetailsAsync(int customerId, int playlistId)
        {
            List<Track> playlists = null;

            using (PlaylistProvider provider = new PlaylistProvider(_context, _logger))
            {
                playlists = await provider.GetAllPlaylistTrackDetailsAsync(playlistId);
            }

            return playlists;
        }

        [HttpPost("customer/{customerId}/addplaylist")]
        public async Task<ActionResult> AddCustomerPlaylistsAsync([FromBody] PlaylistRequest playlist)
        {
            _ = playlist ?? throw new ArgumentNullException(nameof(playlist));

            try
            {
                using (PlaylistProvider provider = new PlaylistProvider(_context, _logger))
                {
                    bool result = await provider.AddCustomerPlaylistAsync(playlist);
                    if (result)
                    {
                        return Ok();
                    }
                    else
                    {
                        return new BadRequestResult();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding customer playlist for customerId: [{playlist.CustomerId}]");
                return new BadRequestResult();
            }
        }
    }
}
