using FuelTrack.API.Back.Contracts.Orders;

namespace FuelTrack.API.Back.Services.Orders;

public interface ISupplierOrderService
{
    IEnumerable<OrderDto> GetOrdersBySupplierCompany(Guid supplierCompanyId, string? status = null);
    OrderDto? GetOrderDetail(Guid supplierCompanyId, Guid orderId);
    OrderDto? UpdateOrderStatus(Guid supplierCompanyId, Guid orderId, string newStatus);
}