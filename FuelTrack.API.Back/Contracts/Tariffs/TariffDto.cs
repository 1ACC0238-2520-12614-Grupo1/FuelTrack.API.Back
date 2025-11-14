namespace FuelTrack.API.Back.Contracts.Tariffs;

public class TariffDto
{
    public Guid Id { get; set; }
    public string Zone { get; set; } = default!;
    public int PriceCents { get; set; }
    public int FreightCents { get; set; }
    public string[] Windows { get; set; } = Array.Empty<string>();
}