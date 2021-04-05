namespace ServerApp.Entities
{
    public class CartLine
    {
        public long CartLineId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
