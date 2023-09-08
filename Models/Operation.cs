using Models.Base;
using Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Operation : BaseEntity<int>
    {
        [Required]
        public virtual Account Account { get; set; } = null!;
        public int AccountId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(double.Epsilon, double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public OperationTypeEnum OperationType { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public Operation() { }
        public Operation(int accountId, decimal amount, OperationTypeEnum type, decimal newBalance)
        {
            AccountId = accountId;
            Amount = amount;
            OperationType = type;
            Balance = newBalance;
            Date = DateTime.UtcNow;
        }

        public static Operation Create(int accountId, decimal amount, OperationTypeEnum type, decimal newBalance)
        {
            return new Operation(accountId, amount, type, newBalance);
        }
    }
}
