using CinemaAppAspNetCoreMVC.Data.Context;
using CinemaAppAspNetCoreMVC.Data.Repositories.Interfaces;
using CinemaAppAspNetCoreMVC.Domain.Models;
using CinemaAppAspNetCoreMVC.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly CinemaDbContext _context;

        public BookingService(IBookingRepository bookingRepository, CinemaDbContext context)
        {
            _bookingRepository = bookingRepository;
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Session)
                .ThenInclude(s => s.Movie)
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
            .Include(b => b.Session)
            .ThenInclude(s => s.Movie)
            .FirstOrDefaultAsync(b => b.Id == id);

        }
        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteAsync(id);
        }
    }
}
