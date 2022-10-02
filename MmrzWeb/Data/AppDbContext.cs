using Microsoft.EntityFrameworkCore;
using MmrzWeb.Authentication;

namespace MmrzWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserAccount> Users { get; set; }
    }
}
