using ContactsAPI.Dtos.Contacts;
using ContactsAPI.Models;
using AutoMapper;

namespace ContactsAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contact, GetContactsResponseDto>();   //Contact -> GetContactsResponseDto
            CreateMap<AddContactRequestDto, Contact>();     //AddContactRequestDto -> Contact
        }
    }
}
