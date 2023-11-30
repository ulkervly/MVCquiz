using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }
        
    }
}
