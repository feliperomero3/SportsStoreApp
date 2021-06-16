namespace ServerApp.Entities
{
    public class Payment
    {
        public long PaymentId { get; private set; }
        public string CardNumber { get; private set; }
        public string CardExpiry { get; private set; }
        public string CardSecurityCode { get; private set; }
        public decimal Total { get; set; }
        public string AuthCode { get; set; }

        public Payment(string cardNumber, string cardExpiry, string cardSecurityCode, decimal total)
        {
            CardNumber = cardNumber;
            CardExpiry = cardExpiry;
            CardSecurityCode = cardSecurityCode;
            Total = total;
        }
    }
}
