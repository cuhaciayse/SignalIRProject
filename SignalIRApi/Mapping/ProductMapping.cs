using AutoMapper;
using SignalIR.DtoLayer.ProductDto;
using SignalIRApi.EntityLayer.Entities;

namespace SignalIRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
               CreateMap<Product,ResultPrdouctDto>().ReverseMap();  
               CreateMap<Product,CreateProductDto>().ReverseMap();  
               CreateMap<Product,UpdateProductDto>().ReverseMap();  
               CreateMap<Product,GetProductDto>().ReverseMap();  
        }
    }
}
