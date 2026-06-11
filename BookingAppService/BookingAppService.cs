using BookingRodico.BookingDataService;
using BookingSystemModels;


namespace BookingRodicoAppService
{
    public class BookingAppService

    {
        BookingDataService dataService = new BookingDataService(new BookingDBData());

        public Booking? AddBooking(string name, string destination, string travelDate,
                              int classChoice, int baggage, int meal)
        {
            if (baggage > 20 || meal > 2)
                return null;

            DateTime parsedDate;
            DateTime.TryParseExact(travelDate, "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out parsedDate);

            if (parsedDate.Date < DateTime.Today)
            return null;

            string travelClass = (classChoice == 2) ? "Business" : "Economy";
            double baseFare = (classChoice == 2) ? 24000.00 : 9000.00;
            double totalPrice = baseFare + (baggage * 300) + (meal * 900);

            var booking = new Booking
            {
                BookingId = Guid.NewGuid(),
                PassengerName = name,
                Destination = destination,
                TravelDate = travelDate,
                TravelClass = travelClass,
                BaggageWeight = baggage,
                MealAmount = meal,
                TotalPrice = totalPrice,
                Status = "Confirmed"
            };

            dataService.AddBooking(booking);
            return booking;
        }


        public bool AgentLogin(string username, string password)
        {
            return username == "agent" && password == "agent123";
        }

        public List<Booking> GetBookings() => dataService.GetBookings();

        public void DeleteBooking(string name) => dataService.DeleteBooking(name);

        public bool UpdateBooking(string name, string destination, int baggage, int meal, string status)
        {

            if (baggage > 20)
            {
                return false;
            }

            if (meal > 2)
            {
                return false; 
            }

            var validStatuses = new[] { "Confirmed", "Delayed", "Cancelled" };
            if (!validStatuses.Contains(status, StringComparer.OrdinalIgnoreCase))
            {

                return false;
            }

            var bookings = dataService.GetBookings();
            var existing = bookings.FirstOrDefault(b => b.PassengerName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existing == null) return false;

            double baseFare = existing.TravelClass == "Business" ? 24000.00 : 9000.00;
            double newTotalPrice = baseFare + (baggage * 300) + (meal * 900);

            dataService.UpdateBooking(name, destination, baggage, meal, status, newTotalPrice);
            return true;

            }

        public Booking AddBooking(string name, string destination)
        {
            var booking = new Booking
            {
                BookingId = Guid.NewGuid(),
                PassengerName = name,
                Destination = destination,
                TravelDate = DateTime.Today.ToString("dd-MM-yyyy"),
                TravelClass = "Economy",
                BaggageWeight = 0,
                MealAmount = 0,
                TotalPrice = 9000.00,
                Status = "Confirmed"
            };

            dataService.AddBooking(booking);
            return booking;
        }

        public bool UpdateBooking(Guid id, string passengerName, string destination)
        {
            var bookings = dataService.GetBookings();
            var existing = bookings.FirstOrDefault(b => b.BookingId == id);

            if (existing == null) return false;

            dataService.DeleteBooking(existing.PassengerName);


            var updated = new Booking
            {
                BookingId = id,
                PassengerName = passengerName,
                Destination = destination,
                TravelDate = existing.TravelDate,
                TravelClass = existing.TravelClass,
                BaggageWeight = existing.BaggageWeight,
                MealAmount = existing.MealAmount,
                Status = existing.Status,
                TotalPrice = existing.TotalPrice
            };

            dataService.AddBooking(updated);

            return true;

        }
    }
}
