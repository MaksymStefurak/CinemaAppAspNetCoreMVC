using CinemaAppAspNetCoreMVC.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaAppAspNetCoreMVC.ViewModels
{
    public class BookSessionViewModel
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public IEnumerable<Session> Sessions { get; set; } = new List<Session>();

        [Required(ErrorMessage = "Будь ласка, оберіть сеанс")]
        [Display(Name = "Сеанс")]
        public int SelectedSessionId { get; set; }
    }
}
