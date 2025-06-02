using CinemaAppAspNetCoreMVC.Domain.Models;
using CinemaAppAspNetCoreMVC.Service.Interfaces;
using CinemaAppAspNetCoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppAspNetCoreMVC.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IMovieService _movieService;
        private readonly IBookingService _bookingService;
        public SessionController(ISessionService sessionService, IMovieService movieService, IBookingService bookingService)
        {
            _sessionService = sessionService;
            _movieService = movieService;
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Book(int movieId)
        {
            var movie = await _movieService.GetMovieByIdAsync(movieId);
            if(movie == null) return NotFound();

            var sessions = await _sessionService.GetSessionsByMovieIdAsync(movie.Id);

            if (!sessions.Any())
            {
                sessions = new List<Session>
        {
            new Session { Id = 1, MovieId = movie.Id, SessionTime = DateTime.Now.AddHours(1) },
            new Session { Id = 2, MovieId = movie.Id, SessionTime = DateTime.Now.AddHours(3) }
        };
            }
            var model = new BookSessionViewModel
            {
                Movie = movie,
                Sessions = sessions
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();

            var model = bookings.Select(b => new MyBookingViewModel
            {
                MovieTitle = b.Session.Movie.Title,
                SessionTime = b.Session.SessionTime,
                BookingDate = b.BookingDate
            }).ToList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(BookSessionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Movie = await _movieService.GetMovieByIdAsync(model.MovieId);
                model.Sessions = await _sessionService.GetSessionsByMovieIdAsync(model.MovieId);
                return View(model);
            }

            var booking = new Booking
            {
                SessionId = model.SelectedSessionId,
                BookingDate = DateTime.Now
            };

            await _bookingService.AddBookingAsync(booking);

            return RedirectToAction("Confirmation");
        }
    }
}



