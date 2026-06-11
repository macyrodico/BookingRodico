using BookingRodico.BookingDataService;
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

        public void UpdateBooking(Guid id, string passengerName, string destination,
                          int baggage, int meal, string status, double totalPrice)
        {
            var bookings = _dataService.GetBookings();
            var existing = bookings.FirstOrDefault(b => b.BookingId == id);

            if (existing != null)
            {
                
                _dataService.DeleteBooking(existing.PassengerName);

                
                var updated = new Booking
                {
                    BookingId = id,
                    PassengerName = passengerName,
                    Destination = destination,
                    BaggageWeight = baggage,
                    MealAmount = meal,
                    Status = status,
                    TotalPrice = totalPrice,
                    TravelDate = existing.TravelDate,
                    TravelClass = existing.TravelClass
                };

                _dataService.AddBooking(updated);
            }
        }
    }

    
}

   

