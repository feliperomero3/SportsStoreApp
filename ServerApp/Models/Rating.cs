namespace ServerApp.Models
{
    public class Rating
    {
        public long RatingId { get; private set; }
        public int Stars { get; private set; }
        public Product Product { get; private set; }

        private Rating()
        {
        }

        public Rating(int stars)
        {
            Stars = stars;
        }
    }
}
