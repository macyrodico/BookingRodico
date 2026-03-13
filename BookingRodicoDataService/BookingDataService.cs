using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystemModels;  


namespace BookingRodicoDataService
{
    public class BookingDataService
    {

        static List<Booking> bookings = new List<Booking>();

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
