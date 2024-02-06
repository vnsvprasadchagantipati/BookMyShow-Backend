using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface ICityService
    {
      
            void CreateCity(City city); 
            List<City> GetAllCities(); 
            void EditCity(City city);
            void DeleteCity(long CityID);
            City GetCityByID(long cityID);

    }
    }

