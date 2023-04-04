using Microsoft.EntityFrameworkCore;


namespace BT_API.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}
