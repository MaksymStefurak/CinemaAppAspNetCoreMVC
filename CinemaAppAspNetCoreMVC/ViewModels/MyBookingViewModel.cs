namespace CinemaAppAspNetCoreMVC.ViewModels
{
    public class MyBookingViewModel
    {
        public int BookingId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime SessionTime { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
