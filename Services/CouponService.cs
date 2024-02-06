using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly MyContext _context;

        public CouponService(MyContext context)
        {
            _context = context;
        }

        public void CreateCoupon(Coupon coupon)
        {
            try
            {
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCoupon(long CouponID)
        {
            Coupon coupon = _context.Coupons.Find(CouponID);
            if (coupon != null) 
            {
                try
                {
                    _context.Coupons.Remove(coupon);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditCoupon(Coupon coupon)
        {
            try
            {
                _context.Coupons.Update(coupon);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Coupon> GetAllCoupons()
        {
            try
            {
                return _context.Coupons.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
