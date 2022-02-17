using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WinterDemo.Domain.Configuration;
using WinterDemo.Domain.Contexts;
using WinterDemo.Domain.Interfaces;
using WinterDemo.Domain.Providers;
using WinterDemo.Service.Controllers;

namespace WinterDemo.UnitTests
{
    [TestClass]
    public class ServiceTests
    {
        private ChinookContext _context = new ChinookContext();
        private ILogger<AccountProvider> _logger = new Logger<AccountProvider>(new LoggerFactory());
        private ILogger<PlaylistProvider> _loggerPlaylist = new Logger<PlaylistProvider>(new LoggerFactory());
        private IAccountProvider _userService;
        private IJwtAuthManager _jwtAuthManager;

        [TestClass]
        public class AccountControllerTests : ServiceTests 
        {
            [TestMethod]
            [TestCategory("WIP")]
            public void ShouldReturnController()
            {
                // Arrange
                _userService = new AccountProvider(_context, _logger);
                _jwtAuthManager = new JwtAuthManager(new JwtTokenConfig { Secret = "mysecret" });

                // Act
                AccountController controller = new AccountController(_context, _logger, _userService, _jwtAuthManager);

                // Assert
                Assert.IsNotNull(controller);
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionWhenContextIsNull()
            {
                // Arrange
                _userService = new AccountProvider(_context, _logger);
                _jwtAuthManager = new JwtAuthManager(new JwtTokenConfig { Secret = "mysecret" });

                // Act
                _ = new AccountController(null, _logger, _userService, _jwtAuthManager);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldReturnExceptionWhenLoggerIsNull()
            {
                // Arrange
                _userService = new AccountProvider(_context, _logger);
                _jwtAuthManager = new JwtAuthManager(new JwtTokenConfig { Secret = "mysecret" });

                // Act
                _ = new AccountController(_context, null, _userService, _jwtAuthManager);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldReturnExceptionWhenServiceIsNull()
            {
                // Arrange
                _userService = new AccountProvider(_context, _logger);
                _jwtAuthManager = new JwtAuthManager(new JwtTokenConfig { Secret = "mysecret" });

                // Act
                _ = new AccountController(_context, _logger, null, _jwtAuthManager);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldReturnExceptionWhenJwtManagerIsNull()
            {
                // Arrange
                _userService = new AccountProvider(_context, _logger);

                // Act
                _ = new AccountController(_context, _logger, _userService, null);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }
        }

        [TestClass]
        public class PlaylistControllerTests : ServiceTests
        {
            [TestMethod]
            [TestCategory("WIP")]
            public void ShouldReturnController()
            {
                // Arrange

                // Act
                PlaylistController controller = new PlaylistController(_context, _loggerPlaylist);

                // Assert
                Assert.IsNotNull(controller);
            }

            [TestMethod]
            [TestCategory("WIP")]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionWhenContextIsNull()
            {
                // Arrange

                // Act
                _ = new PlaylistController(null, _loggerPlaylist);

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
                _ = new PlaylistController(_context, null);

                // Assert
                Assert.Fail("Expected ArgumentNullException!");
            }
        }
    }
}
