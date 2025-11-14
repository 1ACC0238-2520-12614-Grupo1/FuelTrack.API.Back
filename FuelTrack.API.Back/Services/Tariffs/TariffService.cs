using FuelTrack.API.Back.Contracts.Tariffs;
using FuelTrack.API.Back.Infrastructure;
namespace FuelTrack.API.Back.Services.Tariffs;

public class TariffService : ITariffService
{
    public IEnumerable<TariffDto> GetTariffsBySupplierCompany(Guid supplierCompanyId)
    {
        return FakeDataSeeder.Tariffs
            .Where(t => t.SupplierCompanyId == supplierCompanyId)
            .Select(t => new TariffDto
            {
                Id = t.Id,
                Zone = t.Zone,
                PriceCents = t.PriceCents,
                FreightCents = t.FreightCents,
                Windows = t.WindowsCsv
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            });
    }
}