using BookingRodicoAppService;

namespace BookingRodico
{

    class Program
    {

        static BookingAppService bookingService = new BookingAppService();

        static void Main(string[] args)

        {


            while (true)
            {


                Console.WriteLine("\n--- Welcome to AeroVista Flight System ---");
                Console.WriteLine("1. Book a Flight");
                Console.WriteLine("2. View My Booking");
                Console.WriteLine("3. Airline Agent Login (Restricted)");
                Console.WriteLine("4. Exit");
                Console.Write("Selection: ");
                string choice = Console.ReadLine();


                if (choice == "1")
                    AddBooking();

                else if (choice == "2")
                    ViewBooking();

                else if (choice == "3")
                    AgentLogin();

                else if (choice == "4")
                    break;

                else
                    Console.WriteLine("Invalid selection.");
            }
        }


        static void AgentLogin()
        {

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (!bookingService.AgentLogin(username, password))
            {
                Console.WriteLine("Invalid credentials! Access denied.");
                return;
            }

            Console.WriteLine("Welcome, Agent!");

            bool inAgentMenu = true;
            while (inAgentMenu)
            {

                Console.WriteLine("\n--- Airline Agent Control Panel ---");
                Console.WriteLine("1. View All Bookings");
                Console.WriteLine("2. Update Flight Status/Details");
                Console.WriteLine("3. Delete/Cancel Booking");
                Console.WriteLine("4. Logout to Passenger Menu");
                Console.Write("Agent Action: ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        ViewAllBookings();
                        break;
                    case "2":
                        UpdateBooking();
                        break;
                    case "3":
                        DeleteBooking();
                        break;
                    case "4":
                        inAgentMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }



        static void AddBooking()
        {


            Console.Write("Enter Passenger name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter destination: ");
            string? destination = Console.ReadLine();

            Console.Write("Enter Travel Date (DD-MM-YYYY): ");
            string? travelDate = Console.ReadLine();

            Console.WriteLine("Select Class: 1. Economy (Php 9000) | 2. Business (Php 24000)");
            int classChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Baggage Weight (Max 20 kg): ");
            int baggage = Convert.ToInt32(Console.ReadLine());

            Console.Write("Meal Amount (Max 2): ");
            int meal = Convert.ToInt32(Console.ReadLine());


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(destination))
            {
                Console.WriteLine("Name and destination are required.");
                return;
            }

            if(!DateTime.TryParseExact(travelDate, "dd-MM-yyyy", null, 
                System.Globalization.DateTimeStyles.None, out _))
            {
                Console.WriteLine("Invalid date format! Please use DD-MM-YYYY.");
                return;
            }

            var result = bookingService.AddBooking(name, destination, travelDate, classChoice, baggage, meal);

            if (result == null)
                Console.WriteLine("Booking Failed! Date may be in the past, or check baggage/meal limits.");

            else
                Console.WriteLine("Booked! " + result.TravelClass + " to " + result.Destination + ". Total: Php " + result.TotalPrice);


        }


        static void ViewBooking()
        {

            Console.Write("Enter your Passenger Name: ");
            string name = Console.ReadLine();

            var bookings = bookingService.GetBookings();

            var myBookings = bookings.Where(b => b.PassengerName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (myBookings.Count == 0)
            {
                Console.WriteLine("No bookings found for " + name + ".");
                return;
            }

            int i = 1;

            foreach (var booking in myBookings)
            {

                Console.WriteLine("Booking no. " + i);
                Console.WriteLine("Booking ID: " + booking.BookingId);
                Console.WriteLine("Passenger name: " + booking.PassengerName);
                Console.WriteLine("Destination: " + booking.Destination);
                Console.WriteLine("Travel Date: " + booking.TravelDate);
                Console.WriteLine("Class: " + booking.TravelClass);
                Console.WriteLine("Baggage: " + booking.BaggageWeight + "kg");
                Console.WriteLine("Meals: " + booking.MealAmount);
                Console.WriteLine("Total Price: Php " + booking.TotalPrice);

                i++;

            }

        }


        static void ViewAllBookings()
        {

            var bookings = bookingService.GetBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings available.");
                return;
            }

            int i = 1;
            foreach (var booking in bookings)
            {
                Console.WriteLine("Booking no. " + i);
                Console.WriteLine("Booking ID: " + booking.BookingId);
                Console.WriteLine("Passenger name: " + booking.PassengerName);
                Console.WriteLine("Destination: " + booking.Destination);
                Console.WriteLine("Travel Date: " + booking.TravelDate);
                Console.WriteLine("Class: " + booking.TravelClass);
                Console.WriteLine("Baggage: " + booking.BaggageWeight + "kg");
                Console.WriteLine("Meals: " + booking.MealAmount);
                Console.WriteLine("Total Price: Php " + booking.TotalPrice);
                Console.WriteLine("Status: " + booking.Status);
                i++;
            }
        }


        static void UpdateBooking()
        {

            Console.Write("Enter Passenger Name to update: ");
            string name = Console.ReadLine();

            var bookings = bookingService.GetBookings();
            var booking = bookings.FirstOrDefault(b => b.PassengerName.Equals(name, StringComparison.OrdinalIgnoreCase));


            if (booking == null)
            {
                Console.WriteLine("Booking not found!");
                return;
            }

            string destination = booking.Destination;
            int baggage = booking.BaggageWeight;
            int meal = booking.MealAmount;
            string status = booking.Status;
            double totalPrice = booking.TotalPrice;

            bool updating = true;
            while (updating)
            {
                Console.WriteLine("\nUpdating Booking for: " + booking.PassengerName);
                Console.WriteLine("Current Destination: " + destination);
                Console.WriteLine("Current Status: " + status);
                Console.WriteLine("Current Meal Amount: " + meal);
                Console.WriteLine("Current Baggage: " + baggage + "kg");
                Console.WriteLine("Current Total Price: Php " + totalPrice);

                Console.WriteLine("\nWhat would you like to update?");
                Console.WriteLine("1. Destination");
                Console.WriteLine("2. Baggage Weight");
                Console.WriteLine("3. Meal Amount");
                Console.WriteLine("4. Flight Status");
                Console.WriteLine("5. Finish & Save");
                Console.Write("Selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter New Destination: ");
                        destination = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter New Baggage Weight: ");
                        baggage = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Enter New Meal Amount: ");
                        meal = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Enter New Status (Confirmed/Delayed/Cancelled): ");
                        string newStatus = Console.ReadLine();

                        var validStatuses = new[] { "Confirmed", "Delayed", "Cancelled" };
                        if (!validStatuses.Contains(newStatus, StringComparer.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Invalid status! Must be Confirmed, Delayed, or Cancelled.");
                            break;

                        }
                        
                        status = newStatus;
                        Console.WriteLine("Status updated to: " + status);
                        break;

                    case "5":
                        bool success = bookingService.UpdateBooking(name, destination, baggage, meal, status);
                        if (success)
                        {
                            Console.WriteLine("Booking updated successfully.");
                            updating = false;
                        }
                        else
                        {
                            Console.WriteLine("Update failed! Check baggage (Max 20kg), meals (Max 2), or status (Confirmed/Delayed/Cancelled).");
                            
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

        }
                static void DeleteBooking()
                {
                    Console.Write("Enter Passenger Name to delete: ");
                    string name = Console.ReadLine();

                    Console.Write("Confirm Deletion? (y/n): ");
                    string confirm = Console.ReadLine();

                    if (confirm?.ToLower() == "y")
                    {
                        bookingService.DeleteBooking(name);
                        Console.WriteLine("Booking deleted.");
                    }

                    else
                    {
                    Console.WriteLine("Deletion cancelled.");
                    }

                }
    }

}

    




