using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Movie
    { 
            [Key]
            public long MovieID { get; set; }

            [Required]
            [MaxLength(50)]
            [Column(TypeName = "nvarchar(50)")]
            public string? MovName { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime ReleaseDate { get; set; }
            public string ImageUrl { get; set; }
            public long mulID { get; set; }
            [ForeignKey("mulID")]
            public Multiplex Multiplex { get; set; }
    }


    }

