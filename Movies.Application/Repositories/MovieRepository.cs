using Dapper;
using Movies.Application.Database;
using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public MovieRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        async Task<bool> IMovieRepository.CreateAsync(Movie movie)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(new CommandDefinition("""
                insert into movies (id, slug, title, yearofrelease)
                values (@Id, @Slug, @Title, @YearOfRelease)
                """, movie));

            if (result > 0)
            {
                foreach( var genre in movie.Genres)
                {
                    await connection.ExecuteAsync(new CommandDefinition("""
                        insert into genres (movieId, name)
                        values (@MovieID, @Name)
                        """, new { MovieId = movie.Id, Name = genre }));
                }
            }

            transaction.Commit();

            return result > 0;
        }

        Task<Movie?> IMovieRepository.GetByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Movie?> IMovieRepository.GetBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Movie>> IMovieRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IMovieRepository.UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMovieRepository.DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
