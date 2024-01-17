using AutoMapper;
using SignalIR.DtoLayer.ContactDto;
using SignalIR.EntityLayer.Entities;

namespace SignalIRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
             CreateMap<Contact,ResultContactDto>().ReverseMap();    
             CreateMap<Contact,CreateContactDto>().ReverseMap();    
             CreateMap<Contact,UpdateContactDto>().ReverseMap();    
             CreateMap<Contact,GetContactDto>().ReverseMap();    
        }
    }
}
