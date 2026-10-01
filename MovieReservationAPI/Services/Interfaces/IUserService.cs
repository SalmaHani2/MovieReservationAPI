using MovieReservationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReservationAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser> GetByIdAsync(string id);

        Task AddAsync(ApplicationUser user);

        Task SaveChangesAsync();
    }
}