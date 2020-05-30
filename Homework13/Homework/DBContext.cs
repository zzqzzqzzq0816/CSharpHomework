using Microsoft.EntityFrameworkCore;

namespace OrderDB
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            this.Database.EnsureCreated(); 
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
