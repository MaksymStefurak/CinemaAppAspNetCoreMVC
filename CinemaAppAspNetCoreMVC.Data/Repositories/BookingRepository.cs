using CinemaAppAspNetCoreMVC.Data.Context;
using CinemaAppAspNetCoreMVC.Data.Repositories.Interfaces;
using CinemaAppAspNetCoreMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace CinemaAppAspNetCoreMVC.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly CinemaDbContext _context;

        public BookingRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings.Include(b => b.Session).ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings.Include(b => b.Session).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await GetByIdAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
