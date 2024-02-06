using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class City
    { 
            [Key]
            public long CityID { get; set; }

            [Required]
            [MaxLength(30)]
            [Column(TypeName = "nvarchar(30)")]
            //[Index(IsUnique = true)]
            public string? CityName { get; set; }
        }

    }

