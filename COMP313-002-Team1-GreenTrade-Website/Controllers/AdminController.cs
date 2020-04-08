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
    public class AdminController : ControllerBase
    {
        AdminDataAccessLayer admin = new AdminDataAccessLayer();
        [HttpGet]
        public Task<List<Admin>> Get()
        {
            return admin.GetAllAdmins();
        }

        [HttpGet("{email}")]
        public Task<List<Admin>> Get(string email)
        {
            return admin.GetAdminByEmail(email);
        }

        [HttpPost]
        public void Post([FromBody] Admin newAdmin)
        {
            admin.AddAdmin(newAdmin);
        }
        [HttpPut]
        public void Put([FromBody]Admin newAdmin)
        {
            admin.UpdateAdmin(newAdmin);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            admin.DeleteAdminbyId(id);
        }
        [HttpGet("credentials")]
        public Task<bool> credentials([FromBody]Admin newAdmin)
        {
            return admin.checkCredentials(newAdmin);
        }
    }
}