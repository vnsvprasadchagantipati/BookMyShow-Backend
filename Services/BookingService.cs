using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyShowNewWebAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly MyContext _context;

        public BookingService(MyContext context)
        {
            _context = context;
        }

        public void CreateBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void DeleteBooking(long BookingID)
        {
            Booking booking = _context.Bookings.Find(BookingID);
            if (booking != null) 
            {
                try
                {
                    _context.Bookings.Remove(booking);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Booking> GetAllBookings(string UserID)
        {
            try
            {
                return _context.Bookings.Where(u=>u.UserID.ToLower()== UserID.ToLower()).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Booking GetBookingByID(long BookingID)
        {
            try
            {
                return _context.Bookings.Find(BookingID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* public List<BookingDto> GetAllBookingsWithMovName()
         {
             try
             {
                 var bookingsWithMovName = _context.Bookings
                     .Include(b => b.Show)
                     .ThenInclude(s => s.Movie)
                     .Select(b => new BookingDto
                     {
                         BookingID = b.BookingID,
                         Amount = b.Amount,
                         BookingDateTime = b.BookingDateTime,
                         ShowID = b.ShowID,
                         UserID = b.UserID,
                         MovName = b.Show.Movie.MovName // Use MovName field
                     })
                     .ToList();

                 return bookingsWithMovName;
             }
             catch (Exception)
             {
                 throw;
             }
         }*/
        public List<Booking> GetBookingByShowID(long showID)
        {
            try
            {
                return _context.Bookings.Where(b => b.ShowID == showID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
       

    }

}
