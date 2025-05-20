using CinemaAppAspNetCoreMVC.Data.Repositories.Interfaces;
using CinemaAppAspNetCoreMVC.Domain.Models;
using CinemaAppAspNetCoreMVC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Service
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<List<Movie>> GetAllMoviesAsync() => _movieRepository.GetAllAsync();
        public Task<Movie?> GetMovieByIdAsync(int id) => _movieRepository.GetByIdAsync(id);
        public Task AddMovieAsync(Movie movie) => _movieRepository.AddAsync(movie);
        public Task UpdateMovieAsync(Movie movie) => _movieRepository.UpdateAsync(movie);
        public Task DeleteMovieAsync(int id) => _movieRepository.DeleteAsync(id);
        public async Task<List<Movie>> SearchMoviesAsync(string query)
        {
            return await _movieRepository.SearchAsync(query);
        }
    }
}
