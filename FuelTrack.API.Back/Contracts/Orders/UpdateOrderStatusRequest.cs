namespace FuelTrack.API.Back.Contracts.Orders;

public class UpdateOrderStatusRequest
{
    /// <summary>
    /// Nuevo estado del pedido (PendingAssign, Assigned, OnRoute, Delivered, Reconciled, Cancelled).
    /// </summary>
    public string Status { get; set; } = default!;
}