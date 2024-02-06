using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface ICouponService
    {
        void CreateCoupon(Coupon coupon);
        List<Coupon> GetAllCoupons();
        void EditCoupon(Coupon coupon);
        void DeleteCoupon(long CouponID);
    }
}
