using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Domain.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public Session? Session { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
