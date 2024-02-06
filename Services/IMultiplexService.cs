using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface IMultiplexService
    {

        void CreateMultiplex(Multiplex multiplex);
        List<Multiplex> GetAllMultiplexes();
        void EditMultiplex(Multiplex multiplex);
        void DeleteMultiplex(long MulID);
        Multiplex GetMultiplexByID(long MulID);
        List<Multiplex> GetMultiplexByCityID(long cityID);

    }
}
