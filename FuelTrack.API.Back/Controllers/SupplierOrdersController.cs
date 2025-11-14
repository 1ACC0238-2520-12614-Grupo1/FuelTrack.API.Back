using FuelTrack.API.Back.Contracts.Orders;
using FuelTrack.API.Back.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FuelTrack.API.Back.Controllers;

[ApiController]
[Route("supplier/orders")]
public class SupplierOrdersController : ControllerBase
{
    private readonly ISupplierOrderService _service;

    public SupplierOrdersController(ISupplierOrderService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista pedidos asignados a un proveedor, opcionalmente filtrados por estado.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> GetOrders(
        [FromQuery] Guid supplierCompanyId,
        [FromQuery] string? status = null)
    {
        var orders = _service.GetOrdersBySupplierCompany(supplierCompanyId, status);
        return Ok(orders);
    }

    /// <summary>
    /// Obtiene el detalle de un pedido del proveedor.
    /// </summary>
    [HttpGet("{orderId:guid}")]
    public ActionResult<OrderDto> GetOrderDetail([FromQuery] Guid supplierCompanyId, Guid orderId)
    {
        var order = _service.GetOrderDetail(supplierCompanyId, orderId);

        if (order is null)
            return NotFound();

        return Ok(order);
    }

    /// <summary>
    /// Actualiza el estado de un pedido del proveedor.
    /// </summary>
    [HttpPut("{orderId:guid}/status")]
    public ActionResult<OrderDto> UpdateStatus(
        [FromQuery] Guid supplierCompanyId,
        Guid orderId,
        [FromBody] UpdateOrderStatusRequest request)
    {
        var updated = _service.UpdateOrderStatus(supplierCompanyId, orderId, request.Status);

        if (updated is null)
            return BadRequest("Estado inválido o pedido no encontrado.");

        return Ok(updated);
    }
}