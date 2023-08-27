using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model.Entity
{
    [Table("produto")]
    public class Product : BaseEntity
    {
        [Required]
        [Column("nome")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("quantity")]
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
