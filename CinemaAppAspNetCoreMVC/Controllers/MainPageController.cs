using CinemaAppAspNetCoreMVC.Data.Context;
using CinemaAppAspNetCoreMVC.Service;
using CinemaAppAspNetCoreMVC.Service.Interfaces;
using CinemaAppAspNetCoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppAspNetCoreMVC.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IMovieService _movieService;

        public MainPageController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Home()
        {
            var moviesDomain = await _movieService.GetAllMoviesAsync();

            var moviesViewModel = moviesDomain.Select(m => new MainPageMovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Genre = m.Genre,
                Description = m.Description
            }).ToList();

            var viewModel = new MainPageViewModel
            {
                Movies = moviesViewModel
            };

            return View(viewModel);
        }
    }
}
