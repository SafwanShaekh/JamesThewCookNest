using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JamesThew.Models;

namespace JamesThew.Data
{
    // IdentityDbContext<ApplicationUser> se hum Identity tables (AspNetUsers, AspNetRoles, ...) bana sakte hain
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Agar future mein custom DbSets chahiye hon (e.g., MembershipPlans), yahan add karo:
        // public DbSet<MembershipPlan> MembershipPlans { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Yahan hum custom table names, constraints, indexes define kar sakte hain.
            // Example (commented): builder.Entity<ApplicationUser>().Property(u => u.FullName).HasMaxLength(200);
        }
        public DbSet<Subscription> Subscriptions { get; set; }

    }

}

