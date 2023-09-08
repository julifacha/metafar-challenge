using Models.Base;
using Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Card : BaseEntity<int>
    {
        const int MAX_LOGIN_ATTEMPTS = 4;
        [Required]
        public int Number { get; set; }
        [Required]
        public byte[] HashedPin { get; set; } = null!;
        [Required]
        public CardStatusEnum Status { get; set; } = CardStatusEnum.Enabled;
        [Required]
        public virtual Customer Customer { get; set; } = null!;
        public int CustomerId { get; set; }
        public virtual CardLoginAttempts LoginAttempts { get; set; } = null!;
        public virtual Account? Account { get; set; } = null!;
        public void AddFailedLoginAttempt()
        {
            LoginAttempts.FailedAttempts++;

            if (LoginAttempts.FailedAttempts >= MAX_LOGIN_ATTEMPTS)
            {
                Status = CardStatusEnum.Blocked;
            }
        }

        public void ResetLoginAttempts()
        {
            LoginAttempts.FailedAttempts = 0;
        }
    }
}