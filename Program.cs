
using System;


namespace BookingRodico;

class Program
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


            if (count >= 10)
            {

            Console.WriteLine("Booking list is full!");
            return;

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
            return;
        }


            Console.Write("Meal Amount (Max is 2): ");
            int meal = Convert.ToInt32(Console.ReadLine());


            if (meal > 2)
            {

            Console.WriteLine("Meal limit exceeded! Max is 2.");
            return;

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
            return;

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
    

        static void UpdateBooking ()
    {


        Console.Write("Enter Passenger Name to update: ");
        string searchName = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < count; i++)
        {

            if (passengerName[i].ToLower() == searchName.ToLower())
            {
                Console.Write("New Destination: ");
                destination[i] = Console.ReadLine();


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


                baggageWeight[i] = baggage.ToString();
                mealAmount[i] = meal.ToString();


                Console.WriteLine("Booking Updated Successfully!");
                found = true;
                break;

            }
        }

        if (!found)
        {
            Console.WriteLine("Passenger not found.");
        }
    }


        static void DeleteBooking()
        {
            Console.Write("Enter Passenger Name to delete: ");
            string searchName = Console.ReadLine();

            bool found = false;


            for (int i = 0; i < count; i++)
            {

                if (passengerName[i].ToLower() == searchName.ToLower())
                {
                    Console.Write("Are you sure you want to delete? (yes/no): ");
                    string confirm = Console.ReadLine();


                    if (confirm.ToLower() == "yes")
                    {
                        for (int j = i; j < count - 1; j++)
                        {
                            passengerName[j] = passengerName[j + 1];
                            destination[j] = destination[j + 1];
                            baggageWeight[j] = baggageWeight[j + 1];
                            mealAmount[j] = mealAmount[j + 1];
                        }

                        count--;

                        Console.WriteLine("Booking Deleted Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.");
                    }

                    found = true;
                    break;

                }
            }

            if (!found)
            {
                Console.WriteLine("Passenger not found.");
            }
        }
    }




