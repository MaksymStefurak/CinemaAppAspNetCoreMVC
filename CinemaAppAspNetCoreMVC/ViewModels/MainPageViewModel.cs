using CinemaAppAspNetCoreMVC.Domain.Models;

namespace CinemaAppAspNetCoreMVC.ViewModels
{
    public class MainPageMovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Director { get; set; } 
        public Genre Genre { get; set; } 
        public string? Description { get; set; } 
    }
    public class MainPageViewModel
    {
        public List<MainPageMovieViewModel> Movies { get; set; } = new();
    }
}
