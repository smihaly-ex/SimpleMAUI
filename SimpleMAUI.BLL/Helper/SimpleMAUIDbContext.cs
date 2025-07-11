using Microsoft.EntityFrameworkCore;
using SimpleMAUI.BLL.Models;

namespace SimpleMAUI.BLL.Helper
{
    public class SimpleMAUIDbContext : DbContext
    {
        public SimpleMAUIDbContext(DbContextOptions<SimpleMAUIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
