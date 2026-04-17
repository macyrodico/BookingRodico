using BookingRodico.BookingDataService;
using BookingSystemModels;
using System.Text.Json;


namespace BookingRodicoDataService
{
    public class BookingJsonData : IBookingDataService
    {
        private List<Booking> bookings = new List<Booking>();

        private string _jsonFileName;


        public BookingJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Bookings.json";

            PopulateJsonFile();

        }


        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (bookings.Count <= 0)
            {
                bookings.Add(new Booking
                {
                    BookingId = Guid.NewGuid(),
                    PassengerName = "Macy",
                    Destination = "Thailand",
                    TravelDate = "04-22-2026",
                    TravelClass = "Economy",
                    BaggageWeight = 15,
                    MealAmount = 1,
                    TotalPrice = 14400,
                    Status = "Confirmed"
                });

                SaveDataToJsonFile();

            }
        }


        private void SaveDataToJsonFile()
        {

            var json = JsonSerializer.Serialize(bookings, new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(_jsonFileName, json);

        }


        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName))
            {

                File.Create(_jsonFileName).Close();

            }

            string content = File.ReadAllText(_jsonFileName);

            if (string.IsNullOrWhiteSpace(content))
            {
                bookings = new List<Booking>();
                return;
            }

            var result = JsonSerializer.Deserialize<List<Booking>>(
                content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            bookings = result ?? new List<Booking>();
        }


        public void AddBooking(Booking booking)
        {
            RetrieveDataFromJsonFile();
            bookings.Add(booking);
            SaveDataToJsonFile();
        }

        public void DeleteBooking(string passengerName)
        {
            RetrieveDataFromJsonFile();

            bookings.RemoveAll(b =>
                b.PassengerName == passengerName);

            SaveDataToJsonFile();
        }

        public List<Booking> GetBookings()
        {
            RetrieveDataFromJsonFile();
            return bookings;
        }

        public void UpdateBooking(string name, string destination, int baggage, int meal, string status, double totalPrice)
        {
            RetrieveDataFromJsonFile();

            var existingBooking = bookings
                .FirstOrDefault(x => x.PassengerName == name);

            if (existingBooking != null)
            {
                existingBooking.Destination = destination;
                existingBooking.BaggageWeight = baggage;
                existingBooking.MealAmount = meal;
                existingBooking.Status = status;
                existingBooking.TotalPrice = totalPrice;
            }

            SaveDataToJsonFile();
        }

    }
}


      