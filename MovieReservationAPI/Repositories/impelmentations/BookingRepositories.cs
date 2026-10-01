using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;

namespace MovieReservationAPI.Repositories.impelmentations
{
    public class BookingRepositories : IBookingRepositories
    {
        private readonly ApplicationDbContext _context;

        public BookingRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync() => await _context.Bookings.ToListAsync();

        public async Task<Booking> GetByIdAsync(int id) => await _context.Bookings.FindAsync(id);

        public async Task AddAsync(Booking booking) => await _context.Bookings.AddAsync(booking);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}