using Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Category
{
    [Table("categoria")]
    public  class Category : BaseEntity
    {
        [Required]
        [Column("nome")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
