using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using Models.Enum;

namespace Context.Context
{
    public class MetafarDbContext : DbContext
    {
        private readonly IPinHasher _pinHasher; 
        public MetafarDbContext(DbContextOptions<MetafarDbContext> options, IPinHasher pinHasher) : base(options)
        {
            _pinHasher = pinHasher;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.OperationType)
                    .HasMaxLength(20)
                    .HasConversion(new EnumToStringConverter<OperationTypeEnum>());
            });

            modelBuilder.Entity<Account>()
                .HasIndex(entity => entity.Number)
                .IsUnique();

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasIndex(c => c.Number)
                    .IsUnique();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasConversion(new EnumToStringConverter<CardStatusEnum>());
            });

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Julian Sosa" },
                new Customer { Id = 2, Name = "Maria Perez" }
            );

            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1, CustomerId = 1, HashedPin = _pinHasher.Hash("1234"), Number = 12345678 },
                new Card { Id = 2, CustomerId = 2, HashedPin = _pinHasher.Hash("6789"), Number = 87654321 },
                new Card { Id = 3, CustomerId = 1, HashedPin = _pinHasher.Hash("5555"), Number = 15694947 }
            );

            modelBuilder.Entity<CardLoginAttempts>().HasData(
                new CardLoginAttempts { Id = 1, CardId = 1 },
                new CardLoginAttempts { Id = 2, CardId = 2 },
                new CardLoginAttempts { Id = 3, CardId = 3 }
            );

            var now = DateTime.UtcNow;

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, CardId = 1, Number = 123456, Balance = 500000, LastWithdrawalDate = now },
                new Account { Id = 2, CardId = 2, Number = 456789, Balance = 200000, LastWithdrawalDate = now },
                new Account { Id = 3, CardId = 3, Number = 555555, Balance = 0, LastWithdrawalDate = now }
            );

            modelBuilder.Entity<Operation>().HasData(
                new Operation { Id = 1, AccountId = 1, Amount = 50000, Balance = 50000, Date = now.AddMinutes(-20), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 2, AccountId = 1, Amount = 50000, Balance = 100000, Date = now.AddMinutes(-10), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 3, AccountId = 1, Amount = 50000, Balance = 150000, Date = now.AddMinutes(-9), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 4, AccountId = 1, Amount = 50000, Balance = 200000, Date = now.AddMinutes(-8), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 5, AccountId = 1, Amount = 50000, Balance = 250000, Date = now.AddMinutes(-7), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 6, AccountId = 1, Amount = 50000, Balance = 300000, Date = now.AddMinutes(-6), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 7, AccountId = 1, Amount = 50000, Balance = 350000, Date = now.AddMinutes(-5), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 8, AccountId = 1, Amount = 50000, Balance = 400000, Date = now.AddMinutes(-4), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 9, AccountId = 1, Amount = 50000, Balance = 450000, Date = now.AddMinutes(-3), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 10, AccountId = 1, Amount = 25000, Balance = 475000, Date = now.AddMinutes(-2), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 11, AccountId = 1, Amount = 25000, Balance = 500000, Date = now.AddMinutes(-1), OperationType = OperationTypeEnum.Deposit },
                new Operation { Id = 12, AccountId = 2, Amount = 200000, Balance = 200000, Date = now, OperationType = OperationTypeEnum.Deposit }
            );
        }
    }
}
