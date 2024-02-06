using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface IBookingService
    {
        void CreateBooking(Booking booking);
        List<Booking> GetAllBookings(string userID);
        void EditBooking(Booking booking);
        void DeleteBooking(long BookingID);
        Booking GetBookingByID(long BookingID);
        List<Booking> GetBookingByShowID(long showID);
       

    }
}
