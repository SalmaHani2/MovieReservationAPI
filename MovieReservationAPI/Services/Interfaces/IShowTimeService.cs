using MovieReservationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<IEnumerable<Showtime>> GetAllAsync();
        Task<Showtime> GetByIdAsync(int id);
        Task AddAsync(Showtime showTime);
        Task SaveChangesAsync();
    }
}
