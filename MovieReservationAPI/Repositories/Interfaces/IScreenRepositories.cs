using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface IScreenRepositories
    {
        Task<IEnumerable<Screen>> GetAllAsync();
        Task<Screen> GetByIdAsync(int id);
        Task AddAsync(Screen screen);
        Task SaveChangesAsync();
    }
}