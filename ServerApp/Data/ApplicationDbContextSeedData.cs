using System.Linq;
using ServerApp.Entities;

namespace ServerApp.Data
{
    public static class ApplicationDbContextSeedData
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Suppliers.Any())
            {
                return; // Db has been seeded
            }

            var s1 = new Supplier("Splash Dudes", "San Jose", "CA");
            var s2 = new Supplier("Football Town", "Chicago", "IL");
            var s3 = new Supplier("Chess Co", "San Jose", "CA");

            var r1 = new[] { new Rating(4), new Rating(3) };
            var r2 = new[] { new Rating(4), new Rating(3) };
            var r3 = new[] { new Rating(1), new Rating(3) };
            var r4 = new[] { new Rating(3) };
            var r5 = new[] { new Rating(1), new Rating(4), new Rating(3) };
            var r6 = new[] { new Rating(5), new Rating(4) };
            var r7 = new[] { new Rating(3) };

            var p1 = new Product("Kayak", "A boat for one person", "Water sports", 275, s1, r1);
            var p2 = new Product("Life Jacket", "Protective and fashionable", "Water sports", 48.95m, s1, r2);
            var p3 = new Product("Football Ball", "FIFA-approved size and weight", "Football", 19.5m, s2, r3);
            var p4 = new Product("Corner Flags", "Give your pitch a professional touch", "Football", 34.95m, s2, r4);
            var p5 = new Product("Stadium", "Flat-packed 35,000-seat stadium", "Football", 79500, s2, r5);
            var p6 = new Product("Thinking Cap", "Improve brain efficiency by 75%", "Chess", 16, s3, r6);
            var p7 = new Product("Unsteady Chair", "Secretly give your opponent a disadvantage", "Chess", 29.95m, s3, r7);
            var p8 = new Product("Human Chess Board", "A fun game for the family", "Chess", 75, s3);
            var p9 = new Product("Bling-Bling King", "Gold-plated, diamond-studded King", "Chess", 1200, s3);

            context.Products.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9);

            context.SaveChanges();
        }
    }
}
