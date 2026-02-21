
using System.ComponentModel.Design;

namespace BookingRodico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- WELCOME TO FLIGHT BOOKING SYSTEM ---");


            Console.WriteLine("Choose a Booking type:");
            Console.WriteLine("1. Public");
            Console.WriteLine("2. Private");

            string choice = Console.ReadLine();


            if (choice == "1")
            {
                PublicBooking();

            }
            else if (choice == "2")
            {
                PrivateBooking();

            } else
            {
                Console.WriteLine("Invalid choice. Please select either 1 or 2.");
            }



                static void PublicBooking()
                {
                    Console.WriteLine("--- Public Booking. ---");
                    Console.Write("Enter your destination: ");
                    string destination = Console.ReadLine();

                    Console.Write("Enter your departure date: ");
                    string departureDate = Console.ReadLine();

                    Console.Write("Enter Passenger name: ");
                    string name = Console.ReadLine();

                    Console.Write("Meal Preference: ");
                    string mealPreference = Console.ReadLine();

                    Console.WriteLine("Baggage (kg): ");
                    string baggage = Console.ReadLine();


                }

            static void PrivateBooking()
            {
                Console.WriteLine("--- Public Booking. ---");
                Console.Write("Enter your destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter your departure date: ");
                string departureDate = Console.ReadLine();

                Console.Write("Enter Passenger name: ");
                string name = Console.ReadLine();
            }

            }
        }
    }

