using BookingSystemModels;

namespace BookingRodico.BookingDataService
{
    public interface IBookingDataService
    {

        void AddBooking(Booking booking);
        List<Booking> GetBookings();
        void DeleteBooking(string passengerName);
        void UpdateBooking(string name, string destination, int baggage, int meal, string status, double totalPrice);

    }
}
