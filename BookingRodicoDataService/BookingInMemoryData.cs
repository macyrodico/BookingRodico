using BookingRodico.BookingRodicoDataService;
using BookingSystemModels;


namespace BookingRodicoDataService
{
    public class BookingInMemoryData : IBookingDataService
    {

        static List<Booking> bookings = new List<Booking>();
        private BookingJsonData bookingJsonData;

        public BookingInMemoryData(BookingJsonData bookingJsonData)
        {
            this.bookingJsonData = bookingJsonData;
        }



        public void AddBooking (Booking booking)
        {
            bookings.Add(booking);

        }

        public List<Booking> GetBookings()
        {
            return bookings;

        }

        public void DeleteBooking(string passengerName)
        {

            bookings.RemoveAll(b => b.PassengerName.ToLower() == passengerName.ToLower());

        }

        public void UpdateBooking (string name, string destination, int baggage, int meal)
        {
            foreach (var booking in bookings)
             {

                 if (booking.PassengerName.ToLower() == name.ToLower())
                 {

                     booking.Destination = destination;
                     booking.BaggageWeight = baggage;
                     booking.MealAmount = meal;
                     

                 }
            }
            
        }
    }
}
