using FuelTrack.API.Back.Contracts.Tariffs;
namespace FuelTrack.API.Back.Services.Tariffs;

public interface ITariffService
{
    IEnumerable<TariffDto> GetTariffsBySupplierCompany(Guid supplierCompanyId);
}