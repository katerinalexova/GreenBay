using GreenBay.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GreenBay.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
