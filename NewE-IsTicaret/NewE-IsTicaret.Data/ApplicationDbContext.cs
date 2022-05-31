using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewE_IsTicaret.Models;

namespace NewE_IsTicaret.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // veri tabanı bağlantısında tablolarımızı burada tanıtmış olduk
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart>  Carts { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<OrderDetails>  OrderDetails { get; set; }
        public DbSet<OrderProduct>  OrderProducts { get; set; }
        public DbSet<Product>  Products { get; set; }
    }
}