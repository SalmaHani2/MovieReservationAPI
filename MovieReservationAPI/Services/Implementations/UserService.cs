using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepository;

        public UserService(IUserRepositories userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }
    }
}