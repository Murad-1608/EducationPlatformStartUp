using AutoMapper;
using Entity.Concrete;
using Entity.DTOs;

namespace DataAccess.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            //CreateMap<ProductDto, Product>().ReverseMap();
            //CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
