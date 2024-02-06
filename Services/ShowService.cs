using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class ShowService : IShowService
    {
        private readonly MyContext _context;

        public ShowService(MyContext context)
        {
            _context = context;
        }

        public void CreateShow(Show show)
        {
            try
            {
                _context.Shows.Add(show);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteShow(long ShowID)
        {
            Show show = _context.Shows.Find(ShowID);
            if (show != null) 
            {
                try
                {
                    _context.Shows.Remove(show);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditShow(Show show)
        {
            try
            {
                _context.Shows.Update(show);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Show> GetAllShows()
        {
            try
            {
                return _context.Shows.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Show GetShowByID(long showID)
        {
            try
            {
                return _context.Shows.Find(showID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Show> GetShowsByMultiplex(long multiplexId)
        {
            try
            {
                return _context.Shows.Where(s => s.MulID == multiplexId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Show> GetShowsByMovieID(long movieID)
        {
            try
            {
                return _context.Shows.Where(s => s.MovieID == movieID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
