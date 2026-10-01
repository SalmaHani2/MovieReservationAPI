using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;

namespace MovieReservationAPI.Repositories.impelmentations
{
    public class ShowTimeRepositories : IShowTimeRepositories
    {
        private readonly ApplicationDbContext _context;

        public ShowTimeRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Showtime>> GetAllAsync() => await _context.ShowTimes.ToListAsync();

        public async Task<Showtime> GetByIdAsync(int id) => await _context.ShowTimes.FindAsync(id);

        public async Task AddAsync(Showtime showtime) => await _context.ShowTimes.AddAsync(showtime);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}