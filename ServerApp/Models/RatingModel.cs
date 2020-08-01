using System;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class RatingModel
    {
        public long RatingId { get; set; }
        public int Stars { get; set; }

        public static RatingModel GetFromRating(Rating rating)
        {
            if (rating == null) throw new ArgumentNullException(nameof(rating));

            return new RatingModel
            {
                RatingId = rating.RatingId,
                Stars = rating.Stars
            };
        }
    }
}
