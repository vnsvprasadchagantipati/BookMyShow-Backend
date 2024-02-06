using BookMyShowNewWebAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyShowNewWebAPI.Database
{
    public class MyContext : DbContext  
     {
            //define entity set
            private readonly IConfiguration configuration;

            public MyContext(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            
            public DbSet<City>? Cities { get; set; }
            public DbSet<Multiplex>? Multiplexes { get; set; }
            public DbSet<Movie>? Movies { get; set; }
            public DbSet<Show>? Shows { get; set; }
            public DbSet<User>? Users { get; set; }
            public DbSet<Booking>? Bookings { get; set; }
            public DbSet<Wallet>? Wallets { get; set; }
            public DbSet<Coupon>? Coupons { get; set; }

            //configure connection string
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
               
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            }
             protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                  modelBuilder.Entity<Booking>().Property(b => b.Amount).HasColumnType("decimal(18, 2)");

                  modelBuilder.Entity<Coupon>().Property(c => c.Discount).HasColumnType("decimal(18, 2)"); 

                  modelBuilder.Entity<Wallet>().Property(w => w.Balance).HasColumnType("decimal(18, 2)"); 
                  base.OnModelCreating(modelBuilder);
        }

    }
}

