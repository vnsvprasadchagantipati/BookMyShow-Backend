using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class CityService : ICityService
    {
        private readonly MyContext _context;

        public CityService(MyContext context)
        {
            _context = context;
        }

        public void CreateCity(City city)
        {
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCity(long CityID)
        {
            City city = _context.Cities.Find(CityID);
            if (city != null) 
            {
                try
                {
                    _context.Cities.Remove(city);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditCity(City city)
        {
            try
            {
                _context.Cities.Update(city);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<City> GetAllCities()
        {
            try
            {
                return _context.Cities.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public City GetCityByID(long cityID)
        {
            try
            {
                return _context.Cities.FirstOrDefault(city => city.CityID == cityID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
