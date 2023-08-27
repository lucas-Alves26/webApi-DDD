using AutoMapper;
using Model.Entity;
using WebApi.Dto.Category;
using WebApi.Dto.Product;

namespace WebApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto,Product>();
        }
    }
}
