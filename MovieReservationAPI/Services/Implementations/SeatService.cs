using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepositories _seatRepository;

        public SeatService(ISeatRepositories seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _seatRepository.GetAllAsync();
        }

        public async Task<Seat> GetByIdAsync(int id)
        {
            return await _seatRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Seat seat)
        {
            await _seatRepository.AddAsync(seat);
            await _seatRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _seatRepository.SaveChangesAsync();
        }
    }
}
