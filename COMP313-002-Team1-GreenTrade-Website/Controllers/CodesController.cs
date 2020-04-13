using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _COMP313_002_Team1_GreenTrade_Website.DataAccess;
using _COMP313_002_Team1_GreenTrade_Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP313_002_Team1_GreenTrade_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodesController : ControllerBase
    {
        CodesDataAccessLayer objCodes = new CodesDataAccessLayer();
        [HttpGet("{parent}")]
        public Task<List<Codes>> Get(string parent)
        {
            return objCodes.GetAllCodes(parent);
        }

        [HttpPost]
        public void Post([FromBody] Codes obj, [FromQuery] string parent)
        {
            objCodes.AddCodes(obj, parent);
        }
        [HttpPut]
        public void Put([FromBody]Codes obj, [FromQuery] string parent)
        {
            objCodes.UpdateCodes(obj, parent);
        }
        [HttpDelete]
        public void Delete([FromQuery] string id, [FromQuery] string parent)
        {
            objCodes.DeleteCodes(id, parent);
        }
    }
}