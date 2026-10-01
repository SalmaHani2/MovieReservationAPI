using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface IBookingRepositories
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        Task SaveChangesAsync();
    }
}