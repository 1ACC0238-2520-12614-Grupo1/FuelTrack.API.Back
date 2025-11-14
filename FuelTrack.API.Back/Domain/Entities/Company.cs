using FuelTrack.API.Back.Domain.Enums;
namespace FuelTrack.API.Back.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string TaxId { get; set; } = default!;
    public UserRole Type { get; set; } // Client o Supplier
}