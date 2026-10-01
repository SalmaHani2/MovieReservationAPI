using MovieReservationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Interfaces
{
    public interface IScreenService
    {
        Task<IEnumerable<Screen>> GetAllAsync();
        Task<Screen> GetByIdAsync(int id);
        Task AddAsync(Screen screen);
        Task SaveChangesAsync();
    }
}
