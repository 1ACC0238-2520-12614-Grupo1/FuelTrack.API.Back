namespace FuelTrack.API.Back.Contracts.Auth;

public class LoginResponse
{
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public string FullName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string Token { get; set; } = default!; // token fake por ahora
}