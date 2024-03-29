using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using Proyecta.Core.Contracts.Repositories;
using Proyecta.Core.Contracts.Services;
using Proyecta.Core.Entities.Auth;
using Proyecta.Services;

namespace Proyecta.Tests.UnitTests.Auth;

public class AuthServiceFixture
{
    public AuthService AuthService { get; private set; }
    public Mock<IConfiguration> MockConfiguration { get; private set; }
    public Mock<IAuthRepository> MockAuthRepository { get; private set; }
    public Mock<UserManager<ApplicationUser>> MockUserManager { get; private set; }

    public AuthServiceFixture()
    {
        MockConfiguration = new Mock<IConfiguration>();
        var mockLogger = new Mock<ILogger<AuthService>>();
        MockUserManager = new Mock<UserManager<ApplicationUser>>(
            Mock.Of<IUserStore<ApplicationUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);
        MockAuthRepository = new Mock<IAuthRepository>();
        var mockAppUserService = new Mock<IApplicationUserService>();
        
        // Mocking configuration for JwtConfig
        MockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "JwtConfig:Secret"))).Returns(new ConfigurationSectionMock("PROYECTA_APP_KEY"));
        MockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "JwtConfig:Issuer"))).Returns(new ConfigurationSectionMock("PROYECTA_APP"));
        MockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "JwtConfig:Audience"))).Returns(new ConfigurationSectionMock("https://localhost:7134"));
        MockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "JwtConfig:AccessTokenExpirationInMinutes"))).Returns(new ConfigurationSectionMock("30"));
        MockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "JwtConfig:RefreshTokenExpirationInDays"))).Returns(new ConfigurationSectionMock("7"));

        AuthService = new AuthService(
            MockConfiguration.Object,
            mockLogger.Object,
            MockUserManager.Object,
            MockAuthRepository.Object,
            mockAppUserService.Object);
    }
}

