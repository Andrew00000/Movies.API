using Dapper;

namespace Movies.Application.Database
{
    public class DBInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DBInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task InitializeAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            await connection.ExecuteAsync("""
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'movies')
                BEGIN
                    CREATE TABLE movies (
                        id UNIQUEIDENTIFIER PRIMARY KEY,
                        slug VARCHAR(255) NOT NULL,
                        title TEXT NOT NULL,
                        yearofrelease INTEGER NOT NULL
                    );
                END
            """);
        }
    }
}
