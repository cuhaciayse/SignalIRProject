using AutoMapper;
using AutoMapper.Configuration;
using SignalIR.DtoLayer.CategoryDto;
using SignalIRApi.EntityLayer.Entities;

namespace SignalIRApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();   
            CreateMap<Category,CreateCategoryDto>().ReverseMap();   
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();   
            CreateMap<Category,GetCategoryDto>().ReverseMap();   
        }                 
    }
}
