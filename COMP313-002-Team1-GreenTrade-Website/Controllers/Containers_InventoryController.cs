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
    public class Containers_InventoryController : ControllerBase
    {
        ContainersInventoryDataAccessLayer inventory = new ContainersInventoryDataAccessLayer();
        [HttpGet]
        public Task<List<Containers_Inventory>> Get()
        {
            return inventory.GetAllContainersInventory();
        }

        [HttpGet("{size}")]
        public Task<List<Containers_Inventory>> Get(string size)
        {
            return inventory.GetContainerInventoryBySize(size);
        }

        [HttpPost]
        public void Post([FromBody] Containers_Inventory newInventory)
        {
            inventory.AddContainerInventory(newInventory);
        }
        [HttpPut]
        public void Put([FromBody]Containers_Inventory newInventory)
        {
            inventory.UpdateContainerInventory(newInventory);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            inventory.DeleteContainersInventorybyId(id);
        }
    }
}