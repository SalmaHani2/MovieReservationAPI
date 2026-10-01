using System.Collections.Generic;
using System.Threading.Tasks;
using MovieReservationAPI.Models;

namespace MovieReservationAPI.Repositories.Interfaces
{
    public interface IShowTimeRepositories
    {
        Task<IEnumerable<Showtime>> GetAllAsync();
        Task<Showtime> GetByIdAsync(int id);
        Task AddAsync(Showtime showTime);
        Task SaveChangesAsync();
    }
}