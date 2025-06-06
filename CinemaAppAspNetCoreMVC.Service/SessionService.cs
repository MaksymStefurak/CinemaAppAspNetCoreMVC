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
    public class SessionService:ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId)
        {
            return await _sessionRepository.GetSessionsByMovieIdAsync(movieId);
        }
        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _sessionRepository.GetByIdAsync(id);
        }

        public async Task CreateSessionAsync(Session session)
        {
            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeleteSessionAsync(int id)
        {
            await _sessionRepository.DeleteAsync(id);
        }
    }
}
