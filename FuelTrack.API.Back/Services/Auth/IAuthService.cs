using FuelTrack.API.Back.Contracts.Auth;
namespace FuelTrack.API.Back.Services.Auth;

public interface IAuthService
{
    LoginResponse? Login(string email, string password);
}