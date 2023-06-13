using Movies.Application.Models;

namespace Movies.Application.Services
{
    public interface IMovieService
    {
        public Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
        public Task<Movie?> GetByIDAsync(Guid id, Guid? userid = default, CancellationToken token = default);
        public Task<Movie?> GetBySlugAsync(string slug, Guid? userid = default, CancellationToken token = default);
        public Task<IEnumerable<Movie>> GetAllAsync(Guid? userid = default, CancellationToken token = default);
        public Task<Movie?> UpdateAsync(Movie movie, Guid? userid = default, CancellationToken token = default);
        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}
