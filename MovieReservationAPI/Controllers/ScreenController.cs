using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screen>>> GetAll()
        {
            var screens = await _screenService.GetAllAsync();
            return Ok(screens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screen>> GetById(int id)
        {
            var screen = await _screenService.GetByIdAsync(id);
            if (screen == null) return NotFound();
            return Ok(screen);
        }

        [HttpPost]
        public async Task<ActionResult<Screen>> Create([FromBody] Screen screen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _screenService.AddAsync(screen);
            return CreatedAtAction(nameof(GetById), new { id = screen.Id }, screen);
        }
    }
}
