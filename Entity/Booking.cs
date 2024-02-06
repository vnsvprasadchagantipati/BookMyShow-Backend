using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Booking
    {
            [Key]
            public long BookingID { get; set; }

            public long ShowID { get; set; }

            public string? UserID { get; set; }

        [Required]
            public decimal Amount { get; set; }
          


        [Required]
            public DateTime BookingDateTime { get; set; }
            [ForeignKey("ShowID")]
            public Show? Show { get; set; }
            [ForeignKey("UserID")]
            public User? User { get; set; }
        }

    }

