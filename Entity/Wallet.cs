using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowNewWebAPI.Entity
{
    public class Wallet
    { 
            [Key]
            public long WalletID { get; set; }

            [ForeignKey("User")]
            public string? UserID { get; set; }

            [Required]
            public decimal Balance { get; set; }
            [ForeignKey("UserID")]
            public User? User { get; set; }
        }

    }

