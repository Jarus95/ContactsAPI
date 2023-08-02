using ContactsAPI.Dtos.Contacts;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Services.ContactService
{
    public interface IContactService
    {
        Task<ServiceResponse<GetContactsResponseDto>> GetContactById([FromRoute] Guid id);
        Task<ServiceResponse<List<GetContactsResponseDto>>> GetAllContacts();
        Task<ServiceResponse<GetContactsResponseDto>> AddContactRequest(AddContactRequestDto addContactRequest);
        Task<ServiceResponse<GetContactsResponseDto>> UpdateContacts(UpdateContactRequestDto updateContactRequest);
        Task<ServiceResponse<GetContactsResponseDto>> DeleteContact([FromRoute] Guid id);
    }
}
