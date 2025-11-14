using FuelTrack.API.Back.Domain.Enums;
namespace FuelTrack.API.Back.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!; // demo
    public string FullName { get; set; } = default!;
    public UserRole Role { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = default!;
}