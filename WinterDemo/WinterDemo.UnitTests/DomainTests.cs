using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WinterDemo.Domain.Contexts;
using WinterDemo.Domain.Interfaces;
using WinterDemo.Domain.Providers;

namespace WinterDemo.UnitTests
{
    [TestClass]
    public class DomainTests
    {
        private ChinookContext _context = new ChinookContext();
        private ILogger<AccountProvider> _logger = new Logger<AccountProvider>(new LoggerFactory());
        private ILogger<PlaylistProvider> _loggerPlaylist = new Logger<PlaylistProvider>(new LoggerFactory());
        private IAccountProvider _accountProvider;
        private IPlaylistProvider _playlistProvider;

        [TestClass]
        public class AccountProviderTests : DomainTests
        {
            [TestMethod]
            [TestCategory("WIP")]
            public void ShouldReturnAccountProvider()
            {
                // Arrange

                // Act
                _accountProvider = new AccountProvider(_context, _logger);

                // Assert
                Assert.IsNotNull(_accountProvider);
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionWhenContextIsNull()
            {
                // Arrange

                // Act
                _ = new AccountProvider(null, _logger);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldReturnExceptionWhenLoggerIsNull()
            {
                // Arrange

                // Act
                _ = new AccountProvider(_context, null);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }
        }

        [TestClass]
        public class PlaylistProviderTests : DomainTests
        {
            [TestMethod]
            [TestCategory("WIP")]
            public void ShouldReturnAccountProvider()
            {
                // Arrange

                // Act
                _playlistProvider = new PlaylistProvider(_context, _loggerPlaylist);

                // Assert
                Assert.IsNotNull(_playlistProvider);
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionWhenContextIsNull()
            {
                // Arrange

                // Act
                _ = new PlaylistProvider(null, _loggerPlaylist);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldReturnExceptionWhenLoggerIsNull()
            {
                // Arrange

                // Act
                _ = new PlaylistProvider(_context, null);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }
        }
    }
}
