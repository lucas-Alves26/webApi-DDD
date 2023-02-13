using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    [Table("categoria")]
    public class Category : BaseEntity
    {
        [Required]
        [Column("name")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
