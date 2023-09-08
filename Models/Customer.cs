using Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer : BaseEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
