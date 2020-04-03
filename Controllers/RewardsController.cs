using COMP313_002_Team1_GreenTrade_Website.DataAccess;
using COMP313_002_Team1_GreenTrade_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController:ControllerBase
    {
        RewardsDataAccessLayer objPickups = new RewardsDataAccessLayer();
        [HttpGet]
        public Task<List<Rewards>> Get()
        {
            return objPickups.GetAllRewards();
        }

        [HttpGet("{id}")]
        public Task<Rewards> Get(string id)
        {
            return objPickups.GetRewardsData(id);
        }

        [HttpPost]
        public void Post([FromBody] Rewards obj)
        {
            objPickups.AddRewards(obj);
        }
        [HttpPut]
        public void Put([FromBody]Rewards obj)
        {
            objPickups.UpdateRewards(obj);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objPickups.DeleteRewards(id);
        }
    }

}
