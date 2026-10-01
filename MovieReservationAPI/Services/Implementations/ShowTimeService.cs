using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly IShowTimeRepositories _showTimeRepository;

        public ShowTimeService(IShowTimeRepositories showTimeRepository)
        {
            _showTimeRepository = showTimeRepository;
        }

        public async Task<IEnumerable<Showtime>> GetAllAsync()
        {
            return await _showTimeRepository.GetAllAsync();
        }

        public async Task<Showtime> GetByIdAsync(int id)
        {
            return await _showTimeRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Showtime showTime)
        {
            await _showTimeRepository.AddAsync(showTime);
            await _showTimeRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _showTimeRepository.SaveChangesAsync();
        }
    }
}
