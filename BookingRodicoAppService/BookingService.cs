using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystemModels;  
using BookingRodicoDataService;


namespace BookingRodicoAppService
{
    public class BookingService
    {

        BookingDataService dataService = new BookingDataService();

        public void AddBooking(Booking booking)
        {
            dataService.AddBooking(booking);

        }
        public List<Booking> GetBookings()
        {
            return dataService.GetBookings();

        }
        public void DeleteBooking(string name)
        {

            dataService.DeleteBooking(name);
        }

        public void UpdateBooking(string name, string destination, int baggage, int meal)
        {
            dataService.UpdateBooking(name, destination, baggage, meal);

        }
    }
}
