using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreService.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Store> Stores { get; set; }
    }
}