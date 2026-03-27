using BookingSystemModels;
using Microsoft.Data.SqlClient;

namespace BookingRodico.BookingRodicoDataService
{
    public class BookingDBData : IBookingDataService
    {

        private string connectionString
        = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog = BookingRodico; Integrated Security = True;" +
            "TrustServerCertificate = True";

        private SqlConnection sqlConnection;

        public BookingDBData()
        {
            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();

        }

        private void AddSeeds()
        {
            var existing = GetBookings();

            if (existing.Count == 0)
            {
                Booking booking1 = new Booking
                {
                    BookingId = Guid.NewGuid(),
                    PassengerName = "Macy",
                    Destination = "Japan",
                    BaggageWeight = 15,
                    MealAmount = 1
                };

                Booking booking2 = new Booking
                {
                    BookingId = Guid.NewGuid(),
                    PassengerName = "Maria",
                    Destination = "Korea",
                    BaggageWeight = 10,
                    MealAmount = 2
                };

                AddBooking(booking1);
                AddBooking(booking2);

            }

        }


        public void AddBooking(Booking booking)
        {
            var insertStatement =
                "INSERT INTO Bookings VALUES (@BookingId, @PassengerName, @Destination, @BaggageWeight, @MealAmount)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@BookingId", booking.BookingId);
            insertCommand.Parameters.AddWithValue("@PassengerName", booking.PassengerName);
            insertCommand.Parameters.AddWithValue("@Destination", booking.Destination);
            insertCommand.Parameters.AddWithValue("@BaggageWeight", booking.BaggageWeight);
            insertCommand.Parameters.AddWithValue("@MealAmount", booking.MealAmount);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public List<Booking> GetBookings()
        {
            string selectStatement =
                "SELECT BookingId, PassengerName, Destination, BaggageWeight, MealAmount FROM Bookings";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var bookings = new List<Booking>();


            while (reader.Read())
            {
                Booking booking = new Booking();

                booking.BookingId = Guid.Parse(reader["BookingId"].ToString());
                booking.PassengerName = reader["PassengerName"].ToString();
                booking.Destination = reader["Destination"].ToString();
                booking.BaggageWeight = Convert.ToInt32(reader["BaggageWeight"]);
                booking.MealAmount = Convert.ToInt32(reader["MealAmount"]);

                bookings.Add(booking);
            }

            sqlConnection.Close();

            return bookings;

        }


        public void DeleteBooking(string passengerName)
        {
            var deleteStatement =
                "DELETE FROM Bookings WHERE PassengerName = @PassengerName";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@PassengerName", passengerName);

            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }


        public void UpdateBooking(string name, string destination, int baggage, int meal)
        {
            sqlConnection.Open();

            var updateStatement =
                "UPDATE Bookings SET Destination = @Destination, BaggageWeight = @BaggageWeight, MealAmount = @MealAmount WHERE PassengerName = @PassengerName";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Destination", destination);
            updateCommand.Parameters.AddWithValue("@BaggageWeight", baggage);
            updateCommand.Parameters.AddWithValue("@MealAmount", meal);
            updateCommand.Parameters.AddWithValue("@PassengerName", name);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

        }
    }

}
