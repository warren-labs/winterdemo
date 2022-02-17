using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinterDemo.Domain.Contexts;
using WinterDemo.Domain.Interfaces;
using WinterDemo.Domain.Models;

namespace WinterDemo.Domain.Providers
{
    public class AccountProvider : IAccountProvider, IDisposable
    {
        private bool disposedValue;
        private readonly ILogger<AccountProvider> _logger;
        private ChinookContext _context;

        public AccountProvider(ChinookContext context, ILogger<AccountProvider> logger)
        {
            // null checks for injection
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<User> GetAuthorizationAsync(string email)
        {
            User user = null;
            //jacksmith@microsoft.com - valid email for testing

            _logger.LogDebug($"Calling GetAuthorizationAsync() for email: [{email}]");

            try
            {
                Customer customer = await _context.Customer.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

                if (customer != null)
                {
                    _logger.LogDebug($"Loading User object for email: [{email}]");

                    // populate the User object and return
                    user = new User
                    {
                        CustomerId = customer.CustomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Genres = new List<Genre>(),
                        Playlists = new List<Playlist>()
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error executing GetAuthorizationAsync() for email: [{email}]");
            }
            
            return user;
        }

        public string GetUserRole(string userName)
        {
            //if (!IsAnExistingUser(userName))
            //{
            //    return string.Empty;
            //}

            if (userName == "admin")
            {
                return UserRoles.Admin;
            }

            return UserRoles.BasicUser;
        }



        #region Not Implemented fully or tested for this demo
        //public bool IsAnExistingUser(string userName)
        //{
        //    return _users.ContainsKey(userName);
        //}

        //public bool IsValidUserCredentials(string userName, string password)
        //{
        //    _logger.LogInformation($"Validating user [{userName}]");
        //    if (string.IsNullOrWhiteSpace(userName))
        //    {
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        return false;
        //    }

        //    return _users.TryGetValue(userName, out var p) && p == password;
        //}


        #endregion

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
        // ~AccountProvider()
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
