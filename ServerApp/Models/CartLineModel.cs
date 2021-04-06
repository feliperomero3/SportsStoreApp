namespace ServerApp.Models
{
    public class CartLineModel
    {
        public long CartLineId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}