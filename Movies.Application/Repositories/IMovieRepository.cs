using Movies.Application.Models;
using System.Threading;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        public Task<bool> CreateAsync(Movie movie, CancellationToken token);
        public Task<Movie?> GetByIDAsync(Guid id, Guid? userid = default, CancellationToken token = default);
        public Task<Movie?> GetBySlugAsync(string slug, Guid? userid = default, CancellationToken token = default);
        public Task<IEnumerable<Movie>> GetAllAsync(Guid? userid = default, CancellationToken token = default);
        public Task<bool> UpdateAsync(Movie movie, CancellationToken token);
        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token);
        public Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);
    }
}
