using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Show
    {
            [Key]
            public long ShowID { get; set; }

            
            public long MulID { get; set; }

            public long MovieID { get; set; }

            [Required]
            [StringLength(30)]  
            public DateTime ShowDateTime { get; set; }
            public string ShowTiming { get; set; }

        [Required]
            public int AvailableSeats { get; set; }
            [ForeignKey("MulID")]
            public Multiplex? Multiplex { get; set; }
            [ForeignKey("MovieID")]
            public Movie? Movie { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }


    }

