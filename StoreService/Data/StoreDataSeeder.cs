using StoreService.Data;
using Common.Models;
using Microsoft.EntityFrameworkCore;

public static class StoreDataSeeder
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (await context.Stores.AnyAsync())
            return; // Database has already been seeded

        // Hardcoded book IDs to match those in BookDataSeeder
        var hardcodedBookIds = new List<Guid>
        {
            Guid.Parse("1e40c5c4-1b3e-4ae6-b58d-0a85b73ae9a2"), // The Great Gatsby
            Guid.Parse("2c0bc43e-bcc8-4932-a3bc-98cf07d7aaff"), // 1984
            Guid.Parse("3e2d43d8-9f8a-4f03-9136-4e509d577f23"), // To Kill a Mockingbird
            Guid.Parse("8a0a5181-0aa2-4908-b747-e3a0f0304f4f")  // The Catcher in the Rye
        };

        var stores = new List<Store>
        {
            new Store { Id = Guid.NewGuid(), Name = "Main Street Books", BookIds = hardcodedBookIds },
            new Store { Id = Guid.NewGuid(), Name = "Downtown Bookstore", BookIds = hardcodedBookIds },
            new Store { Id = Guid.NewGuid(), Name = "Book Haven", BookIds = hardcodedBookIds }
        };

        await context.Stores.AddRangeAsync(stores);
        await context.SaveChangesAsync();
    }
}
