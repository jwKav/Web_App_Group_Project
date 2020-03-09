﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant_API.Models;

namespace Restaurant_API.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20200309143033_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant_API.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1,
                            BookingDate = new DateTime(2020, 3, 9, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            TableId = 1
                        });
                });

            modelBuilder.Entity("Restaurant_API.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupCount")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "12 Parkstone Avenue",
                            CustomerName = "Jamie Benjamin",
                            EmailAddress = "jb.demo@gmail.com",
                            GroupCount = 2,
                            PhoneNumber = "07836544992"
                        });
                });

            modelBuilder.Entity("Restaurant_API.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int?>("TableCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("TableCategoryId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            IsBooked = false,
                            TableCategoryId = 1
                        },
                        new
                        {
                            TableId = 2,
                            IsBooked = false,
                            TableCategoryId = 2
                        },
                        new
                        {
                            TableId = 3,
                            IsBooked = false,
                            TableCategoryId = 3
                        },
                        new
                        {
                            TableId = 4,
                            IsBooked = false,
                            TableCategoryId = 4
                        },
                        new
                        {
                            TableId = 5,
                            IsBooked = false,
                            TableCategoryId = 5
                        },
                        new
                        {
                            TableId = 6,
                            IsBooked = false,
                            TableCategoryId = 6
                        },
                        new
                        {
                            TableId = 7,
                            IsBooked = false,
                            TableCategoryId = 1
                        },
                        new
                        {
                            TableId = 8,
                            IsBooked = false,
                            TableCategoryId = 2
                        },
                        new
                        {
                            TableId = 9,
                            IsBooked = false,
                            TableCategoryId = 3
                        },
                        new
                        {
                            TableId = 10,
                            IsBooked = false,
                            TableCategoryId = 4
                        },
                        new
                        {
                            TableId = 11,
                            IsBooked = false,
                            TableCategoryId = 5
                        },
                        new
                        {
                            TableId = 12,
                            IsBooked = false,
                            TableCategoryId = 1
                        },
                        new
                        {
                            TableId = 13,
                            IsBooked = false,
                            TableCategoryId = 1
                        },
                        new
                        {
                            TableId = 14,
                            IsBooked = false,
                            TableCategoryId = 1
                        },
                        new
                        {
                            TableId = 15,
                            IsBooked = false,
                            TableCategoryId = 5
                        });
                });

            modelBuilder.Entity("Restaurant_API.Models.TableCategory", b =>
                {
                    b.Property<int>("TableCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TableCapacity")
                        .HasColumnType("int");

                    b.HasKey("TableCategoryId");

                    b.ToTable("TableCategories");

                    b.HasData(
                        new
                        {
                            TableCategoryId = 1,
                            TableCapacity = 2
                        },
                        new
                        {
                            TableCategoryId = 2,
                            TableCapacity = 4
                        },
                        new
                        {
                            TableCategoryId = 3,
                            TableCapacity = 6
                        },
                        new
                        {
                            TableCategoryId = 4,
                            TableCapacity = 8
                        },
                        new
                        {
                            TableCategoryId = 5,
                            TableCapacity = 10
                        },
                        new
                        {
                            TableCategoryId = 6,
                            TableCapacity = 12
                        });
                });

            modelBuilder.Entity("Restaurant_API.Models.Booking", b =>
                {
                    b.HasOne("Restaurant_API.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Restaurant_API.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("Restaurant_API.Models.Table", b =>
                {
                    b.HasOne("Restaurant_API.Models.TableCategory", "TableCategory")
                        .WithMany("Tables")
                        .HasForeignKey("TableCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
