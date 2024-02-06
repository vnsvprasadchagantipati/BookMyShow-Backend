namespace BookMyShowNewWebAPI.DTOs
{
    public class CouponDto
    {
        public long CouponID { get; set; }
        public string? Code { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? Description { get; set; }


    }
}
