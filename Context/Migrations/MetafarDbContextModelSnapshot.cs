﻿// <auto-generated />
using System;
using Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Context.Migrations
{
    [DbContext(typeof(MetafarDbContext))]
    partial class MetafarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastWithdrawalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 500000m,
                            CardId = 1,
                            LastWithdrawalDate = new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            Number = 123456
                        },
                        new
                        {
                            Id = 2,
                            Balance = 200000m,
                            CardId = 2,
                            LastWithdrawalDate = new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            Number = 456789
                        },
                        new
                        {
                            Id = 3,
                            Balance = 0m,
                            CardId = 3,
                            LastWithdrawalDate = new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            Number = 555555
                        });
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("HashedPin")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            HashedPin = new byte[] { 21, 5, 145, 210, 119, 184, 252, 70, 155, 161, 160, 130, 108, 161, 9, 131, 254, 131, 35, 174, 69, 36, 94, 205, 226, 222, 205, 217, 210, 1, 77, 110, 19, 6, 85, 138, 126, 101, 107, 81, 94, 76, 57, 134, 246, 234, 171, 114, 18, 6, 69, 136, 0, 66, 36, 63, 104, 9, 197, 3, 59, 141, 109, 220 },
                            Number = 12345678,
                            Status = "Enabled"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            HashedPin = new byte[] { 79, 77, 218, 189, 94, 17, 98, 162, 228, 116, 28, 8, 238, 223, 55, 65, 107, 254, 2, 149, 93, 240, 46, 176, 127, 217, 2, 29, 235, 152, 49, 190, 117, 165, 111, 218, 18, 131, 232, 9, 183, 15, 198, 106, 57, 160, 151, 67, 171, 203, 23, 141, 144, 192, 68, 192, 169, 104, 99, 61, 111, 40, 180, 225 },
                            Number = 87654321,
                            Status = "Enabled"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            HashedPin = new byte[] { 255, 176, 18, 252, 82, 70, 255, 171, 145, 37, 103, 160, 229, 206, 222, 188, 48, 31, 213, 65, 67, 142, 48, 213, 82, 1, 191, 115, 202, 169, 57, 98, 229, 243, 2, 157, 195, 182, 125, 183, 40, 90, 72, 117, 120, 193, 164, 184, 60, 206, 153, 104, 139, 179, 95, 157, 105, 98, 231, 152, 92, 110, 194, 215 },
                            Number = 15694947,
                            Status = "Enabled"
                        });
                });

            modelBuilder.Entity("Models.CardLoginAttempts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("FailedAttempts")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.ToTable("CardLoginAttempts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 1,
                            FailedAttempts = 0
                        },
                        new
                        {
                            Id = 2,
                            CardId = 2,
                            FailedAttempts = 0
                        },
                        new
                        {
                            Id = 3,
                            CardId = 3,
                            FailedAttempts = 0
                        });
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Julian Sosa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maria Perez"
                        });
                });

            modelBuilder.Entity("Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("OperationType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Operations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 50000m,
                            Date = new DateTime(2023, 9, 8, 19, 47, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 100000m,
                            Date = new DateTime(2023, 9, 8, 19, 57, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 150000m,
                            Date = new DateTime(2023, 9, 8, 19, 58, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 200000m,
                            Date = new DateTime(2023, 9, 8, 19, 59, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 250000m,
                            Date = new DateTime(2023, 9, 8, 20, 0, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 300000m,
                            Date = new DateTime(2023, 9, 8, 20, 1, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 7,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 350000m,
                            Date = new DateTime(2023, 9, 8, 20, 2, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 8,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 400000m,
                            Date = new DateTime(2023, 9, 8, 20, 3, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 9,
                            AccountId = 1,
                            Amount = 50000m,
                            Balance = 450000m,
                            Date = new DateTime(2023, 9, 8, 20, 4, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 10,
                            AccountId = 1,
                            Amount = 25000m,
                            Balance = 475000m,
                            Date = new DateTime(2023, 9, 8, 20, 5, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 11,
                            AccountId = 1,
                            Amount = 25000m,
                            Balance = 500000m,
                            Date = new DateTime(2023, 9, 8, 20, 6, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        },
                        new
                        {
                            Id = 12,
                            AccountId = 2,
                            Amount = 200000m,
                            Balance = 200000m,
                            Date = new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479),
                            OperationType = "Deposit"
                        });
                });

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.HasOne("Models.Card", "Card")
                        .WithOne("Account")
                        .HasForeignKey("Models.Account", "CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Models.CardLoginAttempts", b =>
                {
                    b.HasOne("Models.Card", "Card")
                        .WithOne("LoginAttempts")
                        .HasForeignKey("Models.CardLoginAttempts", "CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Models.Operation", b =>
                {
                    b.HasOne("Models.Account", "Account")
                        .WithMany("Operations")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("LoginAttempts")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
