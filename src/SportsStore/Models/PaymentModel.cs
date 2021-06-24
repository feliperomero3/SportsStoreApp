using SportsStore.Entities;

namespace SportsStore.Models
{
    public class PaymentModel
    {
        public long PaymentId { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CardSecurityCode { get; set; }
        public decimal Total { get; set; }
        public string AuthCode { get; set; }

        public static PaymentModel FromPayment(Payment payment)
        {
            if (payment is null) throw new System.ArgumentNullException(nameof(payment));

            var model = new PaymentModel
            {
                PaymentId = payment.PaymentId,
                CardNumber = payment.CardNumber,
                CardExpiry = payment.CardExpiry,
                CardSecurityCode = payment.CardSecurityCode,
                Total = payment.Total,
                AuthCode = payment.AuthCode
            };

            return model;
        }
    }
}