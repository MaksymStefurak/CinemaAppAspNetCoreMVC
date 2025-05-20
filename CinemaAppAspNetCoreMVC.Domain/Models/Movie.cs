using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Domain.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; } 

        [Required]
        [MaxLength(50)]
        public string? Director { get; set; } 

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; } 

        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
