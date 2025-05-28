using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Domain.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
