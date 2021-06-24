using System;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class RatingModel
    {
        public long RatingId { get; set; }
        public int Stars { get; set; }

        public static RatingModel FromRating(Rating rating)
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
