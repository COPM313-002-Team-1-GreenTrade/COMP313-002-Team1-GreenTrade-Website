using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _COMP313_002_Team1_GreenTrade_Website.Models;
using COMP313_002_Team1_GreenTrade_Website.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP313_002_Team1_GreenTrade_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserDataAccessLayer objUsers = new UserDataAccessLayer();
        [HttpGet]
        public Task<List<Users>> Get()
        {
            return objUsers.GetAllUsers();
        }

        [HttpGet("{email}")]
        public Task<List<Users>> Get(string email)
        {
            return objUsers.GetUserData(email);
        }

        [HttpGet("id/{id}")]
        public Task<Users> GetById(string id)
        {
            return objUsers.GetUsersDataById(id);
        }

        [HttpPost]
        public void Post([FromBody] Users employee)
        {
            objUsers.AddUser(employee);
        }
        [HttpPut]
        public void Put([FromBody]Users employee)
        {
            objUsers.UpdateUser(employee);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objUsers.DeleteUser(id);
        }
    }
}