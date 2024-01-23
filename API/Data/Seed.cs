using API.Models;

namespace API.Data
{
    public class Seed
    {
        public static Task SeedData(DataContext context)
        {
            if (context.Items.Any()) return Task.CompletedTask;

            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Left="AAAAAA==",
                    Right= "AAAABB=="
                },
                new Item
                {
                    Id = 2,
                    Left="AQABAQ==",
                    Right= "AAABCC=="
                },
                new Item
                {
                    Id = 3,
                    Left="AAAABB==",
                    Right= null
                },
                new Item
                {
                    Id = 4,
                    Left= null,
                    Right= "AAAABB=="
                },
                new Item
                {
                    Id = 5,
                    Left="AAAABB==",
                    Right= "AAAABB=="
                },
                new Item
                {
                    Id = 6,
                    Left="AAA==",
                    Right= "AAABBB=="
                },

            };

            context.Items.AddRangeAsync(items);
            context.SaveChangesAsync();

            return Task.CompletedTask;


        }
    }
}
