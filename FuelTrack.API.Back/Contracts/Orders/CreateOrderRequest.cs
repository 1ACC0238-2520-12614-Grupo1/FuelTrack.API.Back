namespace FuelTrack.API.Back.Contracts.Orders;

public class CreateOrderRequest
{
    public Guid ClientCompanyId { get; set; }
    public Guid SupplierCompanyId { get; set; }

    public int VolumeLiters { get; set; }
    public string Zone { get; set; } = default!;
    public string Window { get; set; } = default!;

    public int TotalPriceCents { get; set; }
}