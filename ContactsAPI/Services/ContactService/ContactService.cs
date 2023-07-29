using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsAPI.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly ContactAPIDbContext dbContext;

        public ContactService(ContactAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ActionResult<Contact>> AddContactRequest(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Adress = addContactRequest.Adress,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return contact;
        }

        public async Task<ActionResult<Contact>> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return contact;
            }

            throw new Exception("Not found");
        }

        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<ActionResult<Contact>> GetContactById([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                return contact;
            }

            throw new Exception("Not found");
        }

        public async Task<ActionResult<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                contact.Adress = updateContactRequest.Adress;
                contact.Email = updateContactRequest.Email;
                contact.FullName = updateContactRequest.FullName;
                contact.Phone = updateContactRequest.Phone;
                await dbContext.SaveChangesAsync();
                return contact;
            }

            throw new Exception("Not found");
        }
    }
}
