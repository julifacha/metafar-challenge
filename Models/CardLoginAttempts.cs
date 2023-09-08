using Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CardLoginAttempts : BaseEntity<int>
    {
        [Required]
        public Card Card { get; set; } = null!;
        public int CardId { get; set; }
        public int FailedAttempts { get; set; }
    }
}
