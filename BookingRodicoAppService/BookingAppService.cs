using BookingSystemModels;
using BookingRodicoDataService;
using BookingRodico.BookingRodicoDataService;


namespace BookingRodicoAppService
{
    public class BookingAppService

    {
        BookingDataService dataService = new BookingDataService (new BookingDBData());
        


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
