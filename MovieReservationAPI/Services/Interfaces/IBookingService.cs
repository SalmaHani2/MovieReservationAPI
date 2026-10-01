using MovieReservationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        Task SaveChangesAsync();
    }
}
