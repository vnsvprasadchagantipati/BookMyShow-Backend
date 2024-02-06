using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface IShowService
    {
        void CreateShow(Show show);
        List<Show> GetAllShows();
        void EditShow(Show show);
        void DeleteShow(long ShowID);
        Show GetShowByID(long showID);
        List<Show> GetShowsByMultiplex(long multiplexId);
        List<Show> GetShowsByMovieID(long movieID);
    }
}
