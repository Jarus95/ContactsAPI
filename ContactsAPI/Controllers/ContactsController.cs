using ContactsAPI.Data;
using ContactsAPI.Dtos.Contacts;
using ContactsAPI.Models;
using ContactsAPI.Services.ContactService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactAPIDbContext dbContext;
        private readonly IContactService contactService;
        public ContactsController(ContactAPIDbContext dbContext, IContactService contactService)
        {
            this.dbContext = dbContext;
            this.contactService = contactService;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Contact>> GetContactById([FromRoute] Guid id)
        {
            return Ok(await contactService.GetContactById(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
           return Ok(await contactService.GetAllContacts());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Contact>>> AddContacts(AddContactRequestDto addContactRequest)
        {
            return Ok(await contactService.AddContactRequest(addContactRequest));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Contact>>> UpdateContact(UpdateContactRequestDto updateContactRequest)
        {
            var response = await contactService.UpdateContacts(updateContactRequest);
            if(response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<ServiceResponse<Contact>>> DeleteContact([FromRoute] Guid id)
        {
            return Ok(await contactService.DeleteContact(id));
        }
    }
}
