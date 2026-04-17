using BookingSystemModels;
using Microsoft.Data.SqlClient;

namespace BookingRodico.BookingDataService
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
                Booking booking = new Booking
                {
                    BookingId = Guid.NewGuid(),
                    PassengerName = "Macy",
                    Destination = "Japan",
                    TravelDate = "04-22-2026",
                    TravelClass = "Economy",
                    BaggageWeight = 15,
                    MealAmount = 1,
                    TotalPrice = 9000 + (15 * 300) + (1 * 900),
                    Status = "Confirmed"
                };

                AddBooking(booking);
               

            }

        }


        public void AddBooking(Booking booking)
        {
            var insertStatement =
                "INSERT INTO Bookings VALUES (@BookingId, @PassengerName, @Destination, @BaggageWeight, " +
                "@MealAmount, @TravelDate, @TravelClass, @TotalPrice, @Status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@BookingId", booking.BookingId);
            insertCommand.Parameters.AddWithValue("@PassengerName", booking.PassengerName);
            insertCommand.Parameters.AddWithValue("@Destination", booking.Destination);
            insertCommand.Parameters.AddWithValue("@BaggageWeight", booking.BaggageWeight);
            insertCommand.Parameters.AddWithValue("@MealAmount", booking.MealAmount);
            insertCommand.Parameters.AddWithValue("@TravelDate", booking.TravelDate ?? "");
            insertCommand.Parameters.AddWithValue("@TravelClass", booking.TravelClass ?? "Economy");
            insertCommand.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
            insertCommand.Parameters.AddWithValue("@Status", booking.Status ?? "Confirmed");

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public List<Booking> GetBookings()
        {
            string selectStatement =
                "SELECT BookingId, PassengerName, Destination, BaggageWeight, MealAmount, TravelDate, " +
                "TravelClass, TotalPrice, Status FROM Bookings";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var bookings = new List<Booking>();


            while (reader.Read())
            {
                Booking booking = new Booking();
                {

                    booking.BookingId = Guid.Parse(reader["BookingId"].ToString());
                    booking.PassengerName = reader["PassengerName"].ToString();
                    booking.Destination = reader["Destination"].ToString();
                    booking.BaggageWeight = Convert.ToInt32(reader["BaggageWeight"]);
                    booking.MealAmount = Convert.ToInt32(reader["MealAmount"]);
                    booking.TravelDate = reader["TravelDate"].ToString();
                    booking.TravelClass = reader["TravelClass"].ToString();
                    booking.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
                    booking.Status = reader["Status"].ToString();

                };
                bookings.Add(booking);
            }

            reader.Close();
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


        public void UpdateBooking(string name, string destination, int baggage, int meal, string status, double totalPrice)
        {
            
            var updateStatement =
                "UPDATE Bookings SET Destination = @Destination, BaggageWeight = @BaggageWeight, MealAmount = @MealAmount, " +
                "Status = @Status, TotalPrice = @TotalPrice WHERE PassengerName = @PassengerName";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Destination", destination);
            updateCommand.Parameters.AddWithValue("@BaggageWeight", baggage);
            updateCommand.Parameters.AddWithValue("@MealAmount", meal);
            updateCommand.Parameters.AddWithValue("@Status", status);
            updateCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
            updateCommand.Parameters.AddWithValue("@PassengerName", name);


            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }

}
