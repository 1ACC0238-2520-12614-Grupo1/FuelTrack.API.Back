namespace FuelTrack.API.Back.Domain.Entities;

public class Tariff
{
    public Guid Id { get; set; }
    public Guid SupplierCompanyId { get; set; }

    public string Zone { get; set; } = default!;
    public int PriceCents { get; set; }   // por litro o por pedido
    public int FreightCents { get; set; } // flete

    public string WindowsCsv { get; set; } = default!; // "8-12,12-16"
}