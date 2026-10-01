using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepositories _screenRepository;

        public ScreenService(IScreenRepositories screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<IEnumerable<Screen>> GetAllAsync()
        {
            return await _screenRepository.GetAllAsync();
        }

        public async Task<Screen> GetByIdAsync(int id)
        {
            return await _screenRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Screen screen)
        {
            await _screenRepository.AddAsync(screen);
            await _screenRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _screenRepository.SaveChangesAsync();
        }
    }
}
