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
    public class CareerController : ControllerBase
    {
        CareerDataAccessLayer career = new CareerDataAccessLayer();
        [HttpGet]
        public Task<List<Career>> Get()
        {
            return career.GetAllCareers();
        }

        [HttpGet("{email}")]
        public Task<List<Career>> Get(string email)
        {
            return career.GetCareerByEmail(email);
        }

        [HttpPost]
        public void Post([FromBody] Career newCareer)
        {
            career.AddCareer(newCareer);
        }
        [HttpPut]
        public void Put([FromBody]Career newCareer)
        {
            career.UpdateCareer(newCareer);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            career.DeleteCareerbyId(id);
        }
    }
}