using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTour.Controllers
{
    [Route("api/[controller]")]
    public class SightController : ControllerBase
    {
        // GET: api/sight
        [HttpGet("{filter}", Name = "Get")]
        public async Task<IActionResult> Get(string filter)
        {
            return Ok();
        }

        // GET api/sight/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
