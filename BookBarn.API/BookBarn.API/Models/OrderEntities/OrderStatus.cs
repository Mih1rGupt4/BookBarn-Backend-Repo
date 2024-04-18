namespace BookBarn.API.Models.OrderEntities
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