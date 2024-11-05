using BookService.Data;
using Common.Models;
using Microsoft.EntityFrameworkCore;

public static class BookDataSeeder
{
    public static async Task SeedAsync(BookContext context)
    {
        if (await context.Books.AnyAsync())
            return; // Database has already been seeded

        // Hardcoded book data with fixed IDs
        var books = new List<Book>
        {
            new Book { Id = Guid.Parse("1e40c5c4-1b3e-4ae6-b58d-0a85b73ae9a2"), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishedDate = new DateTime(1925, 4, 10), Price = 10.99m },
            new Book { Id = Guid.Parse("2c0bc43e-bcc8-4932-a3bc-98cf07d7aaff"), Title = "1984", Author = "George Orwell", PublishedDate = new DateTime(1949, 6, 8), Price = 8.99m },
            new Book { Id = Guid.Parse("3e2d43d8-9f8a-4f03-9136-4e509d577f23"), Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishedDate = new DateTime(1960, 7, 11), Price = 12.99m },
            new Book { Id = Guid.Parse("8a0a5181-0aa2-4908-b747-e3a0f0304f4f"), Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublishedDate = new DateTime(1951, 7, 16), Price = 9.99m }
        };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();
    }
}
