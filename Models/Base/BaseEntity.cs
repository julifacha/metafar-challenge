using System.ComponentModel.DataAnnotations;

namespace Models.Base
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
