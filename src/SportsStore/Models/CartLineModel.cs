using SportsStore.Entities;

namespace SportsStore.Models
{
    public class CartLineModel
    {
        public long CartLineId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public static CartLineModel FromCartLine(CartLine line)
        {
            if (line is null) throw new System.ArgumentNullException(nameof(line));

            return new CartLineModel
            {
                CartLineId = line.CartLineId,
                ProductId = line.ProductId,
                Quantity = line.Quantity
            };
        }
    }
}