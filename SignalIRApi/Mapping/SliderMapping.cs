using AutoMapper;
using SignalIR.DtoLayer.SliderDto;
using SignalIR.EntityLayer.Entities;

namespace SignalIRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        }
    }
}
