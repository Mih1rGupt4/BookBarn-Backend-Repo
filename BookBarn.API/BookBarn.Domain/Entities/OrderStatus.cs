namespace BookBarn.Domain.Entities
{
    public enum OrderStatus
    {
        Ordered,
        Cancelled,
        Packed,
        Dispatched,
        OnTheWay,
        Delivered,
        ReturnRequested,
        ReplacedRequested,
        ReturnScheduled,
        ReturnCompleted,
        ReplacedCompleted
    }

}
