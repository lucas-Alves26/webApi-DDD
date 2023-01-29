using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Product
{
    [Table("produto")]
    public class Product
    {
        [Key]
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("quantity")]
        [Display(Name = "Quantidade")]
        [MaxLength(255)]
        public string Quantity { get; set; }
    }
}
