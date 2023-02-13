using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto.Category
{
    public class ReadCategoryDto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Data cadastro")]
        public DateTime DateRegister { get; set; }
    }
}
