using FuelTrack.API.Back.Contracts.Auth;
using FuelTrack.API.Back.Infrastructure;

namespace FuelTrack.API.Back.Services.Auth;

public class AuthService : IAuthService
{
    public LoginResponse? Login(string email, string password)
    {
        var user = FakeDataSeeder.Users
            .FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == password);

        if (user is null)
            return null;

        return new LoginResponse
        {
            UserId = user.Id,
            CompanyId = user.CompanyId,
            FullName = user.FullName,
            Role = user.Role.ToString(),
            Token = $"FAKE-TOKEN-{user.Id}"
        };
    }
}