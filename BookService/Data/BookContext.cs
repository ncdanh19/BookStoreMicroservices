using Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookService.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}