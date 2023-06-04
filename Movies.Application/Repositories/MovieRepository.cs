﻿using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new();
        Task<bool> IMovieRepository.CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(true);
        }

        Task<Movie?> IMovieRepository.GetByIDAsync(Guid id)
        {
            var movie = _movies.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(movie);
        }

        Task<Movie?> IMovieRepository.GetBySlugAsync(string slug)
        {
            var movie = _movies.SingleOrDefault(x => x.Slug == slug);
            return Task.FromResult(movie);
        }

        Task<IEnumerable<Movie>> IMovieRepository.GetAllAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        Task<bool> IMovieRepository.UpdateAsync(Movie movie)
        {
            var movieIndex = _movies.FindIndex( x => x.Id == movie.Id );
            if (movieIndex == -1)
            {
                return Task.FromResult(false);
            }

            _movies[movieIndex] = movie;
            return Task.FromResult(true);
        }

        Task<bool> IMovieRepository.DeleteByIdAsync(Guid id)
        {
            var removedCount = _movies.RemoveAll(x => x.Id == id);
            var movieRemoved = removedCount > 0;

            return Task.FromResult(movieRemoved);
        }
    }
}