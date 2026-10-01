using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetById(string id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Create([FromBody] ApplicationUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddAsync(user);

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                user
            );
        }
    }
}