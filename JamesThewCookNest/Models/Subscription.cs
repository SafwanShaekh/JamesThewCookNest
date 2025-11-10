using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        // ✅ Link User (Foreign Key)
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        // ✅ Plan details
        public string PlanName { get; set; } // "Monthly" or "Annual"

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        // ✅ Subscription validity
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // ✅ Check Active/Expired easily
        public bool IsActive => EndDate > DateTime.Now;
    }
}
