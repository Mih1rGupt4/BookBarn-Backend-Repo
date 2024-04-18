namespace BookBarn.Domain.Entities
{
    public class PaymentDetails
    {
        public double Amount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentSource { get; set; }
    }

}
