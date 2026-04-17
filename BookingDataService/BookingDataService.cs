using BookingSystemModels;

namespace BookingRodico.BookingDataService
{
    public class BookingDataService
    {

        IBookingDataService _dataService;

        public BookingDataService(IBookingDataService bookingDataService)
        {
            _dataService = bookingDataService;

        }

        public void AddBooking(Booking booking)
        {
            _dataService.AddBooking(booking);
        }

        public List<Booking> GetBookings()
        {
            return _dataService.GetBookings();
        }

        public void DeleteBooking(string passengerName)
        {
            _dataService.DeleteBooking(passengerName);
        }

        public void UpdateBooking(string name, string destination, int baggage, int meal, string status, double totalPrice)
        {

            _dataService.UpdateBooking(name, destination, baggage, meal, status, totalPrice);

        }

    }
}

   

