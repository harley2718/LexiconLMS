using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LexiconLMS.Models;

namespace LexiconLMS.DataAccessLayer
{
    public class RegisterContext : DbContext
    {

        public RegisterContext() : base("LexiconLMS")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivitytTypes { get; set; }
    }

    
}