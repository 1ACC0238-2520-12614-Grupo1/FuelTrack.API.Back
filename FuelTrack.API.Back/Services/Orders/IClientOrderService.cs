using FuelTrack.API.Back.Contracts.Orders;
namespace FuelTrack.API.Back.Services.Orders;

public interface IClientOrderService
{
    IEnumerable<OrderDto> GetOrdersByClientCompany(Guid clientCompanyId);
    OrderDto CreateOrder(CreateOrderRequest request);
    OrderDto? GetOrderByIdForClient(Guid clientCompanyId, Guid orderId);
    OrderDto? CancelOrder(Guid clientCompanyId, Guid orderId);
}