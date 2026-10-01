using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser> GetByIdAsync(string id);

        Task AddAsync(ApplicationUser user);

        Task SaveChangesAsync();
    }
}