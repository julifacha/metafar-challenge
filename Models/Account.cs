using Core.Exceptions;
using Models.Base;
using Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Account : BaseEntity<int>
    {
        [Required]
        public int Number { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        [Required]
        public Card Card { get; set; } = null!;
        public int CardId { get; set; } 
        [Required]
        public DateTime LastWithdrawalDate { get; set; }
        public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

        public Operation Withdraw(decimal amount)
        {
            if (amount == 0)
                throw new InvalidAmountException();

            if (amount > Balance)
                throw new InsufficientBalanceException();

            Operation withdrawalOperation = Operation.Create(Id, amount, OperationTypeEnum.Withdrawal, Balance - amount);
            Operations.Add(withdrawalOperation);

            LastWithdrawalDate = withdrawalOperation.Date;
            Balance = withdrawalOperation.Balance;

            return withdrawalOperation;
        }
    }
}
