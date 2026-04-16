using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingSystemModels
{
    public class Booking
    {

        public Guid BookingId { get; set; }
        public string? PassengerName { get; set; }
        public string? Destination { get; set; }
        public int BaggageWeight { get; set; }
        public int MealAmount { get; set; }
        public string? TravelDate { get; set; }
        public string? TravelClass { get; set; }
        public double TotalPrice { get; set; }
        public string? Status { get; set; }

    }
}
