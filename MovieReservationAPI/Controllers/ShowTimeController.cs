using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowTimeController : ControllerBase
    {
        private readonly IShowTimeService _showTimeService;

        public ShowTimeController(IShowTimeService showTimeService)
        {
            _showTimeService = showTimeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Showtime>>> GetAll()
        {
            var showtimes = await _showTimeService.GetAllAsync();
            return Ok(showtimes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Showtime>> GetById(int id)
        {
            var showtime = await _showTimeService.GetByIdAsync(id);
            if (showtime == null) return NotFound();
            return Ok(showtime);
        }

        [HttpPost]
        public async Task<ActionResult<Showtime>> Create([FromBody] Showtime showtime)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _showTimeService.AddAsync(showtime);
            return CreatedAtAction(nameof(GetById), new { id = showtime.Id }, showtime);
        }
    }
}
