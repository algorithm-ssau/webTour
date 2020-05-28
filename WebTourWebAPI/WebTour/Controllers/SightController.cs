using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTour.BLL.DTO;
using WebTour.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTour.Controllers
{
    [Route("api/[controller]")]
    public class SightController : ControllerBase
    {
        private readonly ISightService _sightService;

        public SightController(ISightService sightService)
        {
            _sightService = sightService;
        }

        // GET: api/sight
        [HttpGet]
        public async Task<IActionResult> GetSightListAsync()
        {
            var result = await _sightService.GetSightsFromDBAsync();
            return Ok(result);
        }

        // GET: api/sight/museum
        [HttpGet("category/{filterString}")]
        public async Task<IActionResult> GetSightListAsync(string filterString)
        {
            var filter = new FilterDefinitionDTO { Name = "category", Value = filterString };
            var result = await _sightService.GetSightsFromDBAsync(filter);
            return Ok(result);
        }

        // GET: api/sight/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSightByIdAsync(int id)
        {
            var result = await _sightService.GetSightByIDAsync(id);
            return Ok(result);
        }

        // GET: api/sight/top3
        [HttpGet("top3")]
        public async Task<IActionResult> GetTop3Async()
        {
            var result = await _sightService.GetTop3Sights();
            return Ok(result);
        }

        // GET: api/sight/top3
        [HttpGet("like/{id}")]
        public async Task<IActionResult> LikeSideByIDAsync(int id)
        {
            var result = await _sightService.AddLikeToSightAsync(id);
            return Ok(result);
        }
    }
}
