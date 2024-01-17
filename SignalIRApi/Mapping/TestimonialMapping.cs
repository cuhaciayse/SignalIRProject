﻿using AutoMapper;
using SignalIR.DtoLayer.TestimonialDto;
using SignalIR.EntityLayer.Entities;

namespace SignalIRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
               CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();  
               CreateMap<Testimonial,CreateTestimonialDto>().ReverseMap();  
               CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();  
               CreateMap<Testimonial,GetTestimonialDto>().ReverseMap();  
        }
    }
}
