using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync() => await _context.Movies.ToListAsync();

    public async Task<Movie> GetByIdAsync(int id) => await _context.Movies.FindAsync(id);

    public async Task AddAsync(Movie movie) => await _context.Movies.AddAsync(movie);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}