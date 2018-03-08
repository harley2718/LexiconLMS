using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LexiconLMS.Models;

namespace LexiconLMS.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        //public DbSet<Document> Documents { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivitytTypes { get; set; }
    }

    

}