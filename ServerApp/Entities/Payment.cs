namespace ServerApp.Entities
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CardSecurityCode { get; set; }
        public decimal Total { get; set; }
        public string AuthCode { get; set; }
    }
}
