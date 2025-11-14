using FuelTrack.API.Back.Contracts.Orders;
using FuelTrack.API.Back.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FuelTrack.API.Back.Controllers;


[ApiController]
[Route("client/orders")]
public class ClientOrdersController : ControllerBase
{
    private readonly IClientOrderService _service;

    public ClientOrdersController(IClientOrderService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista los pedidos de un cliente por empresa.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> GetOrders([FromQuery] Guid clientCompanyId)
    {
        var orders = _service.GetOrdersByClientCompany(clientCompanyId);
        return Ok(orders);
    }

    /// <summary>
    /// Crea un nuevo pedido para un cliente.
    /// </summary>
    [HttpPost]
    public ActionResult<OrderDto> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var created = _service.CreateOrder(request);
        return CreatedAtAction(nameof(GetOrderById),
            new { clientCompanyId = request.ClientCompanyId, orderId = created.Id }, created);
    }

    /// <summary>
    /// Obtiene el detalle de un pedido específico del cliente.
    /// </summary>
    [HttpGet("{orderId:guid}")]
    public ActionResult<OrderDto> GetOrderById([FromQuery] Guid clientCompanyId, Guid orderId)
    {
        var order = _service.GetOrderByIdForClient(clientCompanyId, orderId);

        if (order is null)
            return NotFound();

        return Ok(order);
    }

    /// <summary>
    /// Cancela un pedido del cliente.
    /// </summary>
    [HttpPut("{orderId:guid}/cancel")]
    public ActionResult<OrderDto> CancelOrder([FromQuery] Guid clientCompanyId, Guid orderId)
    {
        var cancelled = _service.CancelOrder(clientCompanyId, orderId);

        if (cancelled is null)
            return NotFound();

        return Ok(cancelled);
    }
}