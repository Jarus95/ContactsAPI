using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Services.ContactService
{
    public interface IContactService
    {
        Task<ServiceResponse<Contact>> GetContactById([FromRoute] Guid id);
        Task<ServiceResponse<List<Contact>>> GetAllContacts();
        Task<ServiceResponse<Contact>> AddContactRequest(AddContactRequest addContactRequest);
        Task<ServiceResponse<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest);
        Task<ServiceResponse<Contact>> DeleteContact([FromRoute] Guid id);
    }
}
