using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Multiplex
        {
            [Key]
            public long MulID { get; set; }

            [Required]
            [MaxLength(30)]
            [Column(TypeName = "nvarchar(30)")]
            public string? MulName { get; set; }

          
            public long CityID { get; set; }

            public int ScreenNumber { get; set; }
            [ForeignKey("CityID")]
            public City? City { get; set; }
        }

    }

