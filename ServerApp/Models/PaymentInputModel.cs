using System.ComponentModel.DataAnnotations;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class PaymentInputModel
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardExpiry { get; set; }

        [Required]
        public string CardSecurityCode { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Total must be at least 1")]
        public decimal Total { get; set; }

        public Payment ToPayment()
        {
            return new Payment(CardNumber, CardExpiry, CardSecurityCode, Total);
        }
    }
}
