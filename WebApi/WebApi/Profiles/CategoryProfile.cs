using AutoMapper;
using Model.Entity;
using WebApi.Dto.Category;

namespace WebApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
        }
    }
}
