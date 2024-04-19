namespace BookBarn.Domain.Entities
{
    public enum OrderStatus
    {
        Ordered,
        Packed,
        Dispatched,
        OnTheWay,
        Delivered,
        ReturnRequested,
        ReplacedRequested,
        ReturnScheduled,
        ReturnCompleted,
        ReplacedCompleted,
        Cancelled
    }

}
