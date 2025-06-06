using CinemaAppAspNetCoreMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Service.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync();

        Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId);
        Task<Session> GetSessionByIdAsync(int id);
        Task CreateSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task DeleteSessionAsync(int id);
    }
}
