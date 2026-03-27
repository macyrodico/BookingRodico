using BookingSystemModels;

namespace BookingRodico.BookingRodicoDataService
{
    public interface IBookingDataService
    {

        void AddBooking(Booking booking);
        List<Booking> GetBookings();
        void DeleteBooking(string passengerName);
        void UpdateBooking(string name, string destination, int baggage, int meal);

    }
}
