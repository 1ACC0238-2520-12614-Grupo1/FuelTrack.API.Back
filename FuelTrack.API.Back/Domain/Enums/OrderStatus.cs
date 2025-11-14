namespace FuelTrack.API.Back.Domain.Enums;

public enum OrderStatus
{
    PendingAssign = 1,
    Assigned = 2,
    OnRoute = 3,
    Delivered = 4,
    Reconciled = 5,
    Cancelled = 6
}