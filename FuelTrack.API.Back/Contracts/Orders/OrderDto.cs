namespace FuelTrack.API.Back.Contracts.Orders;


public class OrderDto
{
    public Guid Id { get; set; }
    public int VolumeLiters { get; set; }
    public string Zone { get; set; } = default!;
    public string Window { get; set; } = default!;
    public int TotalPriceCents { get; set; }
    public string Status { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}