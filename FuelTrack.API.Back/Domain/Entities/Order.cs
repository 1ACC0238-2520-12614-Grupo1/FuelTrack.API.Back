using FuelTrack.API.Back.Domain.Enums;
namespace FuelTrack.API.Back.Domain.Entities;


public class Order
{
    public Guid Id { get; set; }

    public Guid ClientCompanyId { get; set; }
    public Guid SupplierCompanyId { get; set; }

    public int VolumeLiters { get; set; }
    public string Zone { get; set; } = default!;
    public string Window { get; set; } = default!; // "8-12", etc.

    public int TotalPriceCents { get; set; }

    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}