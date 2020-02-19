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
            return objPickups.GetPickupData(id);
        }

        [HttpPost]
        public void Post([FromBody] Pickups pickup)
        {
            objPickups.AddPickup(pickup);
        }

        [HttpPut]
        public void Put([FromBody]Pickups pickup)
        {
            objPickups.UpdatePickup(pickup);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objPickups.DeletePickup(id);
        }
    }
}