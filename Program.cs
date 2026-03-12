using System;
using BookingRodicoAppService;
using BookingSystemModels;

namespace BookingRodico
{

    class Program
    {

        static BookingService bookingService = new BookingService();

        static void Main(string[] args)

        {

            while (true)
            {


                Console.WriteLine("--- FLIGHT BOOKING SYSTEM ---");


                Console.WriteLine("Choose a number:");
                Console.WriteLine("1. Add Booking");
                Console.WriteLine("2. View Booking");
                Console.WriteLine("3. Update Booking");
                Console.WriteLine("4. Delete Booking");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();


                if (choice == "1")
                    AddBooking();

                else if (choice == "2")
                    ViewBooking();

                else if (choice == "3")
                    UpdateBooking();

                else if (choice == "4")
                    DeleteBooking();

                else if (choice == "5")
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                }

                else
                    Console.WriteLine("Invalid choice. Please try again.");
            }
        }



        static void AddBooking()
        {


            Console.Write("Enter Passenger name: ");
            string name = Console.ReadLine();

            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();


            Console.WriteLine("Baggage Weight (Max is 20 kg): ");
            int baggage = Convert.ToInt32(Console.ReadLine());


            if (baggage > 20)
            {

                Console.WriteLine("Baggage limit exceeded! Max weight is 20 kg.");
                return;
            }


            Console.Write("Meal Amount (Max is 2): ");
            int meal = Convert.ToInt32(Console.ReadLine());


            if (meal > 2)
            {

                Console.WriteLine("Meal limit exceeded! Max is 2.");
                return;

            }

            Booking newBooking = new Booking
            {
                BookingId = Guid.NewGuid(),
                PassengerName = name,
                Destination = destination,
                BaggageWeight = baggage,
                MealAmount = meal
            };

            bookingService.AddBooking(newBooking);

            Console.WriteLine("Booking Added Successfully!");


        }


        static void ViewBooking()
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

                Console.WriteLine("Booking no. " + (i + 1));
                Console.WriteLine("Passenger name: " + booking.PassengerName);

                Console.WriteLine("Destination: " + booking.Destination);

                Console.WriteLine("Baggage: " + booking.BaggageWeight + "kg");

                Console.WriteLine("Meals: " + booking.MealAmount);

                i++;

            }

        }


        static void UpdateBooking()
        {


            Console.Write("Enter Passenger Name to update: ");
            string name = Console.ReadLine();

           

                if (name.ToLower() == name.ToLower())
                {
                    Console.Write("New Destination: ");
                    string destination = Console.ReadLine();


                    Console.Write("New Baggage Weight (Max 20kg): ");
                    int baggage = Convert.ToInt32(Console.ReadLine());


                    if (baggage > 20)
                    {
                        Console.WriteLine("Baggage exceeded! Update cancelled.");
                        return;

                    }


                    Console.Write("New Meal Count (Max 2): ");
                    int meal = Convert.ToInt32(Console.ReadLine());


                    if (meal > 2)
                    {
                        Console.WriteLine("Meal limit exceeded! Update cancelled.");
                        return;

                    }


                    bookingService.UpdateBooking(name, destination, baggage, meal);


                    Console.WriteLine("Booking Updated Successfully!");
                   

                }
            }


        static void DeleteBooking()
        {
            Console.Write("Enter Passenger Name to delete: ");
            string name = Console.ReadLine();

           



                if (name.ToLower() == name.ToLower())
                {
                    Console.Write("Are you sure you want to delete? (yes/no): ");
                    string confirm = Console.ReadLine();


                    if (confirm.ToLower() == "yes")
                    {
                       
                     bookingService.DeleteBooking(name);
                    Console.WriteLine("Booking Deleted Successfully!");

                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.");
                    }

              
                }
        }

            
    }
}
    




