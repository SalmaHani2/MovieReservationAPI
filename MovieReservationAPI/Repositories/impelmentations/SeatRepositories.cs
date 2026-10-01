using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;

namespace MovieReservationAPI.Repositories.impelmentations
{
    public class SeatRepositories : ISeatRepositories
    {
        private readonly ApplicationDbContext _context;

        public SeatRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetAllAsync() => await _context.Seats.ToListAsync();

        public async Task<Seat> GetByIdAsync(int id) => await _context.Seats.FindAsync(id);

        public async Task AddAsync(Seat seat) => await _context.Seats.AddAsync(seat);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}