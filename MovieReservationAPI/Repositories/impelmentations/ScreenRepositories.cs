using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;

namespace MovieReservationAPI.Repositories.impelmentations
{
    public class ScreenRepositories : IScreenRepositories
    {
        private readonly ApplicationDbContext _context;

        public ScreenRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Screen>> GetAllAsync() => await _context.Screens.ToListAsync();

        public async Task<Screen> GetByIdAsync(int id) => await _context.Screens.FindAsync(id);

        public async Task AddAsync(Screen screen) => await _context.Screens.AddAsync(screen);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}