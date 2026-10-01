using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Repositories.Interfaces;
namespace MovieReservationAPI.Repositories.impelmentations
{
    public class CinemaRepositories:ICinemaRepositories
    {
        private readonly ApplicationDbContext _context;

        public CinemaRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync() => await _context.Cinemas.ToListAsync();

        public async Task<Cinema> GetByIdAsync(int id) => await _context.Cinemas.FindAsync(id);

        public async Task AddAsync(Cinema cinema) => await _context.Cinemas.AddAsync(cinema );

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
