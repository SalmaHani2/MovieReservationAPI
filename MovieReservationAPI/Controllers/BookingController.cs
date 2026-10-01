using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _bookingService.AddAsync(booking);
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }
    }
}
