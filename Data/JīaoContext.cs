using Jīao.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Jīao.Data
{
    public class JīaoContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<MarketStall> MarketStalls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public JīaoContext(DbContextOptions<JīaoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Seller>()
                .HasMany(s => s.MarketStalls)
                .WithOne(ms => ms.Seller)
                .HasForeignKey(ms => ms.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketStall>()
                .HasMany(ms => ms.Categories)
                .WithOne(c => c.MarketStall)
                .HasForeignKey(c => c.MarketStallId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Menus)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Menus)
                .WithMany(m => m.Carts);

            var seller = new Seller
            {
                Id = 1,
                FirtName = "Mei",     
                LastName = "Zhang",
                Password = "hash_demo",
                State = Jīao.Models.Enum.State.Active
            };
            modelBuilder.Entity<Seller>().HasData(seller);

            var stall = new MarketStall
            {
                Id = 1,
                Name = "Jīao Noodle Bar",
                Description = "Ramen & dumplings",
                Location = "Centro",
                SellerId = seller.Id
            };
            modelBuilder.Entity<MarketStall>().HasData(stall);

            var cat = new Category
            {
                Id = 1,
                Name = "Ramen",
                MarketStallId = stall.Id
            };
            modelBuilder.Entity<Category>().HasData(cat);

            var menu1 = new Menu
            {
                Id = 1,
                Name = "Tonkotsu Ramen",
                Price = 6500m,
                Stock = 50,
                Description = "Caldo intenso, chashu, negi",
                ImageUrl = "https://pics.example/ramen1.jpg",
                CategoryId = cat.Id
            };
            var menu2 = new Menu
            {
                Id = 2,
                Name = "Gyoza (6)",
                Price = 4200m,
                Stock = 100,
                Description = "Dumplings de cerdo",
                ImageUrl = "https://pics.example/gyoza.jpg",
                CategoryId = cat.Id
            };
            modelBuilder.Entity<Menu>().HasData(menu1, menu2);

            var karen = new User
            {
                Id = 1,
                FirstName = "Karen",
                LastName = "Lasot",
                Address = "Av Siempre Viva 742",
                Email = "karenbailapiola@gmail.com",
                Password = "Pa$$w0rd",
                State = Jīao.Models.Enum.State.Active
            };
            var luis = new User
            {
                Id = 2,
                FirstName = "Luis",
                LastName = "Gonzales",
                Address = "Calle Falsa 123",
                Email = "elluismidetotoras@gmail.com",
                Password = "lamismadesiempre",
                State = Jīao.Models.Enum.State.Active
            };
            modelBuilder.Entity<User>().HasData(karen, luis);

            var cart = new Cart
            {
                Id = 1,
                UserId = luis.Id
            };
            modelBuilder.Entity<Cart>().HasData(cart);

            base.OnModelCreating(modelBuilder);
        }


    }
}
