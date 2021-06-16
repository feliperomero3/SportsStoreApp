namespace ServerApp.Entities
{
    public class CartLine
    {
        public long CartLineId { get; private set; }
        public long ProductId { get; private set; }
        public int Quantity { get; private set; }

        public CartLine(long productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
