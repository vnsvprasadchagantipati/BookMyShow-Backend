using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Coupon
    { 
            [Key]
            public long CouponID { get; set; }

            [Required]
            [MaxLength(20)]
            [Column(TypeName = "nvarchar(20)")]
            // [Index(IsUnique = true)]
            public string? Code { get; set; }

            [Required]
            public decimal Discount { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime ExpirationDate { get; set; }

            [MaxLength(100)]
            [Column(TypeName = "nvarchar(100)")]
            public string? Description { get; set; }

        }
    }
