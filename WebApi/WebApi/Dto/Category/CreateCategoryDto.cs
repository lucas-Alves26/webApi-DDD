using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
