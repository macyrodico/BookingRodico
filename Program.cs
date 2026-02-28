
using System;


namespace BookingRodico
{
    internal class Program
    {


        static string[] passengerName = new string[10];
        static string[] destination = new string[10];
        static string[] baggageWeight = new string[10];
        static string[] mealAmount = new string[10];

        static int count = 0;

        static void Main(string[] args)

        {

            while (true) 
            {


                Console.WriteLine("--- WELCOME TO FLIGHT BOOKING SYSTEM ---");


                Console.WriteLine("Choose a number:");
                Console.WriteLine("1. Add Booking");
                Console.WriteLine("2. View Booking");
                Console.WriteLine("3. Update Booking");

                string choice = Console.ReadLine();


                if (choice == "1")
                    AddBooking();

                else if (choice == "2")
                    ViewBooking();

                else if (choice == "3")
                    //UpdateBooking();

                else
                    Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    


                static void AddBooking()
                {


                if (count >= 10)
                {

                Console.WriteLine("Booking list is full!");

            }


                Console.Write("Enter Passenger name: ");
                passengerName[count] = Console.ReadLine();

                Console.Write("Enter destination: ");
                destination[count] = Console.ReadLine();


                Console.WriteLine("Baggage Weight (Max is 20 kg): ");
                int baggage = Convert.ToInt32(Console.ReadLine());


                if (baggage > 20)
                {

                Console.WriteLine("Baggage limit exceeded! Max weight is 20 kg.");

            }


                Console.Write("Meal Amount (Max is 2): ");
                int meal = Convert.ToInt32(Console.ReadLine());


                if (meal > 2)
                {

                Console.WriteLine("Meal limit exceeded! Max is 2.");

            }

                baggageWeight[count] = baggage.ToString();
                mealAmount[count] = meal.ToString();

                count++;

                Console.WriteLine("Booking Added Successfully!");


        }

            static void ViewBooking()
            {

            
            if (count == 0)
            {
                Console.WriteLine("No bookings available.");

            }


            for (int i = 0; i < count; i++)
            {

                Console.WriteLine("Booking no. " + (i + 1));
                Console.WriteLine("Passenger name: " + passengerName[i]);

                Console.WriteLine("Destination: " + destination[i]);

                Console.WriteLine("Baggage: " + baggageWeight[i] + "kg");

                Console.WriteLine("Meals: " + mealAmount[i]);


            }
                
               

            }
        }
    }

