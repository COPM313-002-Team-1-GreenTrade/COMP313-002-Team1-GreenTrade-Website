using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP313_002_Team1_GreenTrade_Website.DataAccess;
using COMP313_002_Team1_GreenTrade_Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP313_002_Team1_GreenTrade_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        ContactUsDataAccessLayer contact = new ContactUsDataAccessLayer();
        [HttpGet]
        public Task<List<ContactUs>> Get()
        {
            return contact.GetAllContacts();
        }

        [HttpGet("{email}")]
        public Task<List<ContactUs>> Get(string email)
        {
            return contact.GetContactByEmail(email);
        }

        [HttpPost]
        public void Post([FromBody] ContactUs newContact)
        {
            contact.AddContact(newContact);
        }
        [HttpPut]
        public void Put([FromBody]ContactUs newContact)
        {
            contact.UpdateContact(newContact);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            contact.DeleteContactbyId(id);
        }
    }
}