using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_API.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {

        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
            : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableCategory> TableCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //builder.UseSqlServer("RestaurantDb");
                builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RestaurantDb; Integrated Security = True;" +
                    " Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasKey(c => c.CustomerId);
            builder.Entity<Booking>()
                .HasKey(b => b.BookingId);
            builder.Entity<Table>()
                .HasKey(t => t.TableId);
            builder.Entity<TableCategory>()
                .HasKey(tc => tc.TableCategoryId);

            builder.Entity<Table>()
                .HasOne(t => t.TableCategory)
                .WithMany(tc => tc.Tables)
                .HasForeignKey(t => t.TableCategoryId);

         
            builder.Entity<TableCategory>().HasData(
                new TableCategory { TableCategoryId = 1, TableCapacity = 2 },
                new TableCategory { TableCategoryId = 2, TableCapacity = 4 },
                new TableCategory { TableCategoryId = 3, TableCapacity = 6 },
                new TableCategory { TableCategoryId = 4, TableCapacity = 8 },
                new TableCategory { TableCategoryId = 5, TableCapacity = 10 },
                new TableCategory { TableCategoryId = 6, TableCapacity = 12 });

            builder.Entity<Table>().HasData(
                new Table { TableId = 1, TableCategoryId = 1, IsBooked = true},
                new Table { TableId = 2, TableCategoryId = 2},
                new Table { TableId = 3, TableCategoryId = 3},
                new Table { TableId = 4, TableCategoryId = 4},
                new Table { TableId = 5, TableCategoryId = 5},
                new Table { TableId = 6, TableCategoryId = 6},
                new Table { TableId = 7, TableCategoryId = 1},
                new Table { TableId = 8, TableCategoryId = 2},
                new Table { TableId = 9, TableCategoryId = 3},
                new Table { TableId = 10, TableCategoryId = 4},
                new Table { TableId = 11, TableCategoryId = 5},
                new Table { TableId = 12, TableCategoryId = 1},
                new Table { TableId = 13, TableCategoryId = 1},
                new Table { TableId = 14, TableCategoryId = 1},
                new Table { TableId = 15, TableCategoryId = 5}
                );

            builder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, GroupCount = 2, CustomerName = "Jamie Benjamin", 
                    EmailAddress = "jb.demo@gmail.com", Address = "12 Parkstone Avenue", PhoneNumber = "07836544992"}
                );

            builder.Entity<Booking>().HasData(
                new Booking { BookingId = 1, CustomerId = 1, TableId = 1, BookingDate = new DateTime(2020, 03, 09, 13, 30, 0) }
                );

        }

    }
}
