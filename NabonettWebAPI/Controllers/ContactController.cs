using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NabonettWebAPI.Controllers
{
    [Route ("Contacts")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]

        public async Task<IReadOnlyCollection<Contact>> GetAllAsync()
        {

            var contact = await contactService.GetAllAsync();

            return contact;

        }


        [HttpGet("/id/{id}")]

        public async Task<Contact> GetAsync(string id)
        {

            var conto = await contactService.GetContactAsync(id);

            return conto;

        }


        [HttpGet("/email/{email}")]

        public async Task<Contact> GetByEmailAsync(string email)
        {

            var conto = await contactService.GetByEmailAsync(email);

            return conto;

        }

        //   [HttpPost]

        // public async Task<Contact> Update()
        //   {
        // //     var update = await contactService.GetAllAsync();



    }
}
    
//