
using Microsoft.EntityFrameworkCore;


namespace AmanaTechnology.Model
{
    public class AmanaDbContext : DbContext
    {

        public AmanaDbContext(DbContextOptions<AmanaDbContext> options) : base(options)
        {
        }
        public DbSet<Blogs> Blogs { get; set; }
    }
}

