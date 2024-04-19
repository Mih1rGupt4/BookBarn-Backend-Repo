namespace BookBarn.Domain.Entities
{
    public enum OrderStatus
    {
        Ordered,
        Packed,
        Dispatched,
        OnTheWay,
        ReturnRequested,
        ReplacedRequested,
        ReturnScheduled,
        Delivered,
        ReturnCompleted,
        ReplacedCompleted,
        Cancelled
    }

}
