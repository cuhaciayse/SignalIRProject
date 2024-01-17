using AutoMapper;
using AutoMapper.Configuration;
using SignalIR.DtoLayer.AboutDto;
using SignalIRApi.EntityLayer.Entities;
using System.Runtime;

namespace SignalIRApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
        }
    }
}
