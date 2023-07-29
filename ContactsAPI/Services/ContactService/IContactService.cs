using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Services.ContactService
{
    public interface IContactService
    {
        Task<ActionResult<Contact>> GetContactById([FromRoute] Guid id);
        Task<ActionResult<List<Contact>>> GetAllContacts();
        Task<ActionResult<Contact>> AddContactRequest(AddContactRequest addContactRequest);
        Task<ActionResult<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest);
        Task<ActionResult<Contact>> DeleteContact([FromRoute] Guid id);
    }
}
