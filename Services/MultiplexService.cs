using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class MultiplexService : IMultiplexService
    {
        private readonly MyContext _context;

        public MultiplexService(MyContext context)
        {
            _context = context;
        }

        public void CreateMultiplex(Multiplex multiplex)
        {
            try
            {
                _context.Multiplexes.Add(multiplex);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMultiplex(long MulID)
        {
            Multiplex multiplex = _context.Multiplexes.Find(MulID);
            if (multiplex != null) 
            {
                try
                {
                    _context.Multiplexes.Remove(multiplex);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditMultiplex(Multiplex multiplex)
        {
            try
            {
                _context.Multiplexes.Update(multiplex);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Multiplex> GetAllMultiplexes()
        {
            try
            {
                return _context.Multiplexes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Multiplex GetMultiplexByID(long MulID)
        {
            try
            {
                return _context.Multiplexes.FirstOrDefault(m => m.MulID == MulID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Multiplex> GetMultiplexByCityID(long cityID)
        {
            try
            {
                return _context.Multiplexes.Where(m => m.CityID == cityID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
