﻿
using ContactsAPI.Data;
using ContactsAPI.Dtos.Contacts;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsAPI.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly ContactAPIDbContext dbContext;
        private readonly IMapper mapper;

        public ContactService(ContactAPIDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            
        }

        public async Task<ServiceResponse<GetContactsResponseDto>> AddContactRequest(AddContactRequestDto addContactRequest)
        {
            var serviceResponse = new ServiceResponse<GetContactsResponseDto>();
            var contact = mapper.Map<Contact>(addContactRequest);
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            serviceResponse.Data = mapper.Map<GetContactsResponseDto>(contact);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactsResponseDto>> DeleteContact([FromRoute] Guid id)
        {
            var serviceResponse = new ServiceResponse<GetContactsResponseDto>();
            var contact = await dbContext.Contacts.FindAsync(id);
            serviceResponse.Data = mapper.Map<GetContactsResponseDto>(contact);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactsResponseDto>>> GetAllContacts()
        {
            var serviceResponse = new ServiceResponse<List<GetContactsResponseDto>>();
            var contacts = await dbContext.Contacts.ToListAsync();
            serviceResponse.Data = contacts.Select(c => mapper.Map<GetContactsResponseDto>(c)).ToList();
            return  serviceResponse;
        }

        public async Task<ServiceResponse<GetContactsResponseDto>> GetContactById([FromRoute] Guid id)
        {
            var serviceResponse = new ServiceResponse<GetContactsResponseDto>();
            var contact = await dbContext.Contacts.FindAsync(id);
            serviceResponse.Data = mapper.Map<GetContactsResponseDto>(contact);
            return serviceResponse;
        }

        //public async Task<ServiceResponse<GetContactsResponseDto>> UpdateContact([FromRoute] Guid id, UpdateContactRequestDto updateContactRequest)
        //{
        //    var serviceResponse = new ServiceResponse<GetContactsResponseDto>();
        //    var contact = await dbContext.Contacts.FindAsync(id);
        //    if (contact != null)
        //    {
        //        contact.Adress = updateContactRequest.Adress;
        //        contact.Email = updateContactRequest.Email;
        //        contact.FullName = updateContactRequest.FullName;
        //        contact.Phone = updateContactRequest.Phone;
        //        await dbContext.SaveChangesAsync();
        //    }
        //    serviceResponse.Data = mapper.Map<GetContactsResponseDto>(contact);

        //    return serviceResponse;
        //}
    }
}