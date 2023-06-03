using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> CreateAsync(Movie movie);
        Task<Movie?> GetByIDAsync(Guid id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
