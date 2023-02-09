using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("dateRegister")]
        public DateTime DateRegister { get; set; }

        [Column("dateUpdate")]
        public DateTime? DateUpdate { get; set; }
    }
}
