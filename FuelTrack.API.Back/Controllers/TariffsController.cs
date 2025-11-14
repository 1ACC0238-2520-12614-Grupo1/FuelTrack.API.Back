using FuelTrack.API.Back.Contracts.Tariffs;
using FuelTrack.API.Back.Services.Tariffs;
using Microsoft.AspNetCore.Mvc;




namespace fueltrack.backend.app.Controllers;

[ApiController]
[Route("supplier/tariffs")]
public class TariffsController : ControllerBase
{
    private readonly ITariffService _service;

    public TariffsController(ITariffService service)
    {
        _service = service;
    }

    // GET /supplier/tariffs?supplierCompanyId=...
    [HttpGet]
    public ActionResult<IEnumerable<TariffDto>> GetTariffs([FromQuery] Guid supplierCompanyId)
    {
        var tariffs = _service.GetTariffsBySupplierCompany(supplierCompanyId);
        return Ok(tariffs);
    }
}