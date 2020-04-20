using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTour.BLL.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTour.Controllers
{
    [Route("api/[controller]")]
    public class SightController : ControllerBase
    {
        // GET: api/sights
        [HttpGet("{filter}", Name = "Get")]
        public async Task<IActionResult> GetSightListAsync(FilterDefinitionDTO[] filter)
        {
            return Ok();
        }

        // GET api/sight/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSightByIdAsync(int id)
        {
            return Ok();
        }

        // GET api/sight/top3
        [HttpGet("top3")]
        public async Task<IActionResult> GetTopThreeAsync(int id)
        {
            return Ok();
        }
    }
}
