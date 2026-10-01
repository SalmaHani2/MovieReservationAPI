using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface ISeatRepositories
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<Seat> GetByIdAsync(int id);
        Task AddAsync(Seat seat);
        Task SaveChangesAsync();
    }
}