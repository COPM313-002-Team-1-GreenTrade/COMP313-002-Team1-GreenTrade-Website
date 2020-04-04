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
    public class ContainersController : ControllerBase
    {
        ContainersDataAccessLayer container = new ContainersDataAccessLayer();
        [HttpGet]
        public Task<List<Containers>> Get()
        {
            return container.GetAllContainers();
        }

        [HttpGet("{size}")]
        public Task<List<Containers>> Get(string size)
        {
            return container.GetContainerBySize(size);
        }

        [HttpPost]
        public void Post([FromBody] Containers newContainers)
        {
            container.AddContainer(newContainers);
        }
        [HttpPut]
        public void Put([FromBody]Containers newContainers)
        {
            container.UpdateContainer(newContainers);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            container.DeleteContainersbyId(id);
        }
    }
}