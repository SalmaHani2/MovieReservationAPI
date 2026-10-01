using MovieReservationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task SaveChangesAsync();
    }
}
