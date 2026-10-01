using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAll()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetById(int id)
        {
            var seat = await _seatService.GetByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }

        [HttpPost]
        public async Task<ActionResult<Seat>> Create([FromBody] Seat seat)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _seatService.AddAsync(seat);
            return CreatedAtAction(nameof(GetById), new { id = seat.Id }, seat);
        }
    }
}
