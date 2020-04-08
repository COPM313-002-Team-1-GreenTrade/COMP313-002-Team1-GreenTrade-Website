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
    public class PickupsController : ControllerBase
    {
        PickupsDataAccessLayer objPickups = new PickupsDataAccessLayer();
        [HttpGet]
        public Task<List<Pickups>> Get()
        {
            return objPickups.GetAllPickups();
        }

        [HttpGet("{id}")]
        public Task<Pickups> Get(string id)
        {
            return objPickups.GetPickupsData(id);
        }

        [HttpGet("collectors/{id}")]
        public Task<List<Pickups>> GetCollectors(string id)
        {
            return objPickups.GetPickupDataByCollectorId(id);
        }

        [HttpGet("members/{id}")]
        public Task<List<Pickups>> GetMembers(string id)
        {
            return objPickups.GetPickupDataByMemberId(id);
        }

        [HttpPost]
        public void Post([FromBody] Pickups pickup)
        {
            objPickups.AddPickup(pickup);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Pickups pickup, string id)
        {
            objPickups.UpdatePickup(pickup, id);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objPickups.DeletePickup(id);
        }
    }
}