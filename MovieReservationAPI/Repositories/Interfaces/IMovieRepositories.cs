using MovieReservationAPI.Models;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie> GetByIdAsync(int id);
    Task AddAsync(Movie movie);
    Task SaveChangesAsync();
}