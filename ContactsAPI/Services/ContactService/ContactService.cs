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

        public async Task<ServiceResponse<Contact>> AddContactRequest(AddContactRequest addContactRequest)
        {
            var serviceResponse = new ServiceResponse<Contact>();
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
            serviceResponse.Data = contact;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Contact>> DeleteContact([FromRoute] Guid id)
        {
            var serviceResponse = new ServiceResponse<Contact>();
            var contact = await dbContext.Contacts.FindAsync(id);
            serviceResponse.Data = contact;

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Contact>>> GetAllContacts()
        {
            var serviceResponse = new ServiceResponse<List<Contact>>();
            serviceResponse.Data = await dbContext.Contacts.ToListAsync();
            return  serviceResponse;
        }

        public async Task<ServiceResponse<Contact>> GetContactById([FromRoute] Guid id)
        {
            var serviceResponse = new ServiceResponse<Contact>();
            var contact = await dbContext.Contacts.FindAsync(id);
            serviceResponse.Data = contact;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Contact>> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var serviceResponse = new ServiceResponse<Contact>();
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.Adress = updateContactRequest.Adress;
                contact.Email = updateContactRequest.Email;
                contact.FullName = updateContactRequest.FullName;
                contact.Phone = updateContactRequest.Phone;
                serviceResponse.Data = contact;
                await dbContext.SaveChangesAsync();
            }

            return serviceResponse;
        }
    }
}
