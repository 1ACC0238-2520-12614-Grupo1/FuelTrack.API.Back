using FuelTrack.API.Back.Contracts.Orders;
using FuelTrack.API.Back.Domain.Entities;
using FuelTrack.API.Back.Domain.Enums;
using FuelTrack.API.Back.Infrastructure;

namespace FuelTrack.API.Back.Services.Orders;

public class ClientOrderService : IClientOrderService
{
    public IEnumerable<OrderDto> GetOrdersByClientCompany(Guid clientCompanyId)
    {
        return FakeDataSeeder.Orders
            .Where(o => o.ClientCompanyId == clientCompanyId)
            .OrderByDescending(o => o.CreatedAt)
            .Select(MapToDto);
    }

    public OrderDto CreateOrder(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            ClientCompanyId = request.ClientCompanyId,
            SupplierCompanyId = request.SupplierCompanyId,
            VolumeLiters = request.VolumeLiters,
            Zone = request.Zone,
            Window = request.Window,
            TotalPriceCents = request.TotalPriceCents,
            Status = OrderStatus.PendingAssign,
            CreatedAt = DateTime.UtcNow
        };

        FakeDataSeeder.Orders.Add(order);

        return MapToDto(order);
    }

    public OrderDto? GetOrderByIdForClient(Guid clientCompanyId, Guid orderId)
    {
        var order = FakeDataSeeder.Orders
            .FirstOrDefault(o => o.Id == orderId && o.ClientCompanyId == clientCompanyId);

        return order is null ? null : MapToDto(order);
    }

    public OrderDto? CancelOrder(Guid clientCompanyId, Guid orderId)
    {
        var order = FakeDataSeeder.Orders
            .FirstOrDefault(o => o.Id == orderId && o.ClientCompanyId == clientCompanyId);

        if (order is null)
            return null;

        // Podrías validar estados permitidos aquí
        order.Status = OrderStatus.Cancelled;

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
