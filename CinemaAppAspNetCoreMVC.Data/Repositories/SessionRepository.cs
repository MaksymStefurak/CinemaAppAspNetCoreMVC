using CinemaAppAspNetCoreMVC.Data.Context;
using CinemaAppAspNetCoreMVC.Data.Repositories.Interfaces;
using CinemaAppAspNetCoreMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Data.Repositories
{
    public class SessionRepository:ISessionRepository
    {
        private readonly CinemaDbContext _context;

        public SessionRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await _context.Sessions.Include(s => s.Movie).ToListAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _context.Sessions.Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId)
        {
            return await _context.Sessions.Where(s => s.MovieId == movieId).ToListAsync();
        }

        public async Task AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Session session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if(session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
