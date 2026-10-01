using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepositories _cinemaRepository;

        public CinemaService(ICinemaRepositories cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _cinemaRepository.GetAllAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _cinemaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _cinemaRepository.AddAsync(cinema);
            await _cinemaRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _cinemaRepository.SaveChangesAsync();
        }
    }
}
