using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface ICinemaRepositories
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task SaveChangesAsync();

    }
}
