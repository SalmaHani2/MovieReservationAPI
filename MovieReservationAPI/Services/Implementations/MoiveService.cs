using MovieReservationAPI.Models;
using MovieReservationAPI.Repositories.Interfaces;
using MovieReservationAPI.Services.Interfaces;

namespace MovieReservationAPI.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveChangesAsync();
        }
    }
}