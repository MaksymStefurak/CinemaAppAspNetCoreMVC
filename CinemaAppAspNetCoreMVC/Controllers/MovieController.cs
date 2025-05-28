using CinemaAppAspNetCoreMVC.Domain.Models;
using CinemaAppAspNetCoreMVC.Service.Interfaces;
using CinemaAppAspNetCoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppAspNetCoreMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //public async Task<IActionResult> Home()
        //{
        //    var moviesDomain = await _movieService.GetAllMoviesAsync();

        //    var moviesViewModel = moviesDomain.Select(m => new MainPageController
        //    {
        //        Id = m.Id,
        //        Title = m.Title,
        //        Director = m.Director,
        //        Genre = m.Genre,
        //        Description = m.Description
        //    }).ToList();

        //    var viewModel = new HomePageViewModel
        //    {
        //        Movies = moviesViewModel
        //    };

        //    return View(viewModel);
        //}

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.UpdateMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
