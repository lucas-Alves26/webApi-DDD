using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Category
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "O ID da categoria é obrigatório!")]
        [Display(Name = "Código")]

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

    }
}
