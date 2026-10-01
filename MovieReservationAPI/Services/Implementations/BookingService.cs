using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepositories _bookingRepository;

        public BookingService(IBookingRepositories bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _bookingRepository.SaveChangesAsync();
        }
    }
}
