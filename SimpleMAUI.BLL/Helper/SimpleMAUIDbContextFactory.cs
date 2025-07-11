using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleMAUI.BLL.Helper
{
    public class SimpleMAUIDbContextFactory : IDesignTimeDbContextFactory<SimpleMAUIDbContext>
    {
        public SimpleMAUIDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleMAUIDbContext>();

            var connectionString = Environment.GetEnvironmentVariable("DBConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new SimpleMAUIDbContext(optionsBuilder.Options);
        }
    }
}
