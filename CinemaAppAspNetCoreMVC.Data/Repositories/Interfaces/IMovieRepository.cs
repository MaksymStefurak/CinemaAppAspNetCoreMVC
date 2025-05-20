using CinemaAppAspNetCoreMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Data.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync (int id);
        Task AddAsync (Movie movie);
        Task UpdateAsync (Movie movie);
        Task DeleteAsync (int id);  
        Task<List<Movie>> SearchAsync(string query);
    }
}
