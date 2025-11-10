using System;
using Microsoft.AspNetCore.Identity;

namespace JamesThew.Models
{
    // ApplicationUser extends IdentityUser (default identity fields: Id, UserName, Email, PasswordHash, etc.)
    // Yahan hum apne extra fields add kar sakte hain (FullName, MembershipExpiry etc.)
    public class ApplicationUser : IdentityUser
    {
        // User ka full name (optional)
        public string? FullName { get; set; }

        // Member subscription expiry date (nullable agar free user ho to null rahe)
        public DateTime? MembershipExpiry { get; set; }

        // Is tarah aur bhi profile fields add kar sakte ho (Address, PhoneVerified, etc.)
        // public bool IsEmailVerified { get; set; }
    }
}
