using FuelTrack.API.Back.Contracts.Orders;
using FuelTrack.API.Back.Domain.Entities;
using FuelTrack.API.Back.Domain.Enums;
using FuelTrack.API.Back.Infrastructure;

namespace FuelTrack.API.Back.Services.Orders;

public class SupplierOrderService : ISupplierOrderService
{
    public IEnumerable<OrderDto> GetOrdersBySupplierCompany(Guid supplierCompanyId, string? status = null)
    {
        var query = FakeDataSeeder.Orders
            .Where(o => o.SupplierCompanyId == supplierCompanyId);

        if (!string.IsNullOrWhiteSpace(status) &&
            Enum.TryParse<OrderStatus>(status, ignoreCase: true, out var parsedStatus))
        {
            query = query.Where(o => o.Status == parsedStatus);
        }

        return query
            .OrderByDescending(o => o.CreatedAt)
            .Select(MapToDto);
    }

    public OrderDto? GetOrderDetail(Guid supplierCompanyId, Guid orderId)
    {
        var order = FakeDataSeeder.Orders
            .FirstOrDefault(o => o.Id == orderId && o.SupplierCompanyId == supplierCompanyId);

        return order is null ? null : MapToDto(order);
    }

    public OrderDto? UpdateOrderStatus(Guid supplierCompanyId, Guid orderId, string newStatus)
    {
        if (!Enum.TryParse<OrderStatus>(newStatus, ignoreCase: true, out var parsedStatus))
            return null;

        var order = FakeDataSeeder.Orders
            .FirstOrDefault(o => o.Id == orderId && o.SupplierCompanyId == supplierCompanyId);

        if (order is null)
            return null;

        order.Status = parsedStatus;
        return MapToDto(order);
    }

    private static OrderDto MapToDto(Order o)
    {
        return new OrderDto
        {
            Id = o.Id,
            VolumeLiters = o.VolumeLiters,
            Zone = o.Zone,
            Window = o.Window,
            TotalPriceCents = o.TotalPriceCents,
            Status = o.Status.ToString(),
            CreatedAt = o.CreatedAt
        };
    }
}