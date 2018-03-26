namespace LexiconLMS.Migrations
{
    using LexiconLMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Qqq
    {
        public static int Spunk = 0;

        public static int GetSpunk()
        {
            LexiconLMS.Migrations.Qqq.Spunk += 1;
            return LexiconLMS.Migrations.Qqq.Spunk;
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        public static void _addTeacher(ApplicationDbContext context,
                                       UserManager<ApplicationUser> userManager,
                                       string email,
                                       string password  = "pppppp",
                                       string firstName = "fn placeholder",
                                       string surName   = "en placeholder")
        {
            string userName = email;

            if (context.Users.Any(u => u.UserName == userName)) {
                return;
            }

            var user = new ApplicationUser { UserName = email, Email = email };
            var result = userManager.Create(user, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            context.SaveChanges();

            ApplicationUser aUser;
            aUser = userManager.FindByName(userName);
            userManager.AddToRole(aUser.Id, Role.Teacher);

            context.SaveChanges();
        }

        public static void _addStudent(ApplicationDbContext context,
                                       UserManager<ApplicationUser> userManager,
                                       string email,
                                       string CourseName = "C#",
                                       string password = "pppppp",
                                       string firstName = "fn placeholder",
                                       string surName = "en placeholder",
                                       int courseId = 1)
        {
            string userName = email;

            if (context.Users.Any(u => u.UserName == userName))
            {
                return;
            }

            int? courseIdContainer = courseId;

            var user = new ApplicationUser { UserName = email, Email = email, CourseId = courseIdContainer };
            var result = userManager.Create(user, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            context.SaveChanges();

#if false
            ApplicationUser aUser = userManager.FindByName(userName);
            userManager.AddToRole(aUser.Id, Role.Student);
            context.SaveChanges();
#endif
        }

        public static void _addUser   (ApplicationDbContext context,
                                       UserManager<ApplicationUser> userManager,
                                       int courseId,
                                       string email = "e2@e.e",
                                       string CourseName = "CC#",
                                       string password = "qpppppp",
                                       string firstName = "fn2 placeholder",
                                       string surName = "en3 placeholder")
        {
            System.Console.WriteLine("HEJ");
            string userName = "user" + Qqq.GetSpunk().ToString() + "@d.t";

            if (context.Users.Any(u => u.UserName == userName))
            {
                System.Console.WriteLine("HEJ2");
                return;
            }

            System.Console.WriteLine("HEJ3");
            int? courseIdContainer = courseId;

            System.Console.WriteLine("HEJ4");
            ApplicationUser user;
            if (courseId == 0) {
                System.Console.WriteLine("HEJ5");
                user = new ApplicationUser { UserName = userName, Email = email };
            } else {
                System.Console.WriteLine("HEJ6");
                //user = new ApplicationUser { UserName = userName, Email = email, CourseId = courseIdContainer };
                user = new ApplicationUser { UserName = userName, Email = email, CourseId = courseIdContainer.Value };
            }
            System.Console.WriteLine("HEJ7");
            var result = userManager.Create(user, password);
            System.Console.WriteLine("HEJ8");
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            context.SaveChanges();
#if false
            ApplicationUser aUser;
            aUser = userManager.FindByName(userName);
            userManager.AddToRole(aUser.Id, Role.Student);
            context.SaveChanges();
#endif
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { Role.Teacher };  // Role.Student was removed.
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                // Create role
                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            context.SaveChanges();

            context.Courses.AddOrUpdate(
               c => c.Name,
               new Course { Name = "Python 1", StartDate = DateTime.Now.AddDays(2), Content = "Python är ett programmeringsspråk som låter dig arbeta snabbt och integrera system mer effektivt. Python har vuxit sig extremt starkt på sista tiden. Idag är Google, YouTube, Pinterest, DropBox, Instagram med fler skrivna i Python." },
               new Course { Name = "Python 2", StartDate = DateTime.Now.AddDays(2), Content = " Python 2 - Intermediate. This course gives you an introduction to more advanced concepts in the Python language and starts where the course ends." },
               new Course { Name = "C#", StartDate = DateTime.Now.AddDays(2), Content = "This training course teaches developers the programming skills that are required for developers to create applications using the C# language and .NET 4.5. During their five days in the classroom students review the basics of C# program structure, language syntax, and implementation details, and then consolidate their knowledge throughout the week as they build an application that incorporates several features of the .NET Framework 5" },
               new Course { Name = "Java programmering - Grundkurs ", StartDate = DateTime.Now.AddDays(2), Content = "Kursen tar upp såväl grundläggande syntax som kunskap från Javas viktigaste bibliotek med stöd för datalogiska klasser i Collections Framework och nyheterna från Java 8, kommunikation med databaser samt skapande av professionella GUI. Du får även lära dig hur man skriver och kör enhetstester med ramverket JUnit. Dessutom ingår introduktion till trådprogrammering och förpackning och distribution av Java-applikationer." },
               new Course { Name = "Java programmering - Avancerad", StartDate = DateTime.Now.AddDays(2), Content = " Det här utbildningen är för dig som vill gå vidare och lära dig avancerad Javaprogrammering! Du får lära dig hur man tillämpar beprövade DesignPatterns, olika tekniker för att hantera XML-filer, såväl för konfiguration som för lagring av data. Du får lära dig hur man skriver avancerade multitrådade applikationer med hjälp av såväl traditionella trådklasser som med ramverket Executor Framework." },
               new Course { Name = "GIT kurs", StartDate = DateTime.Now.AddDays(2), Content = "Git är ett populärt, flexibelt, avancerat och öppet källkodsverktyg som ökar teamets produktivitet. GIT är uppbyggt för att passa arbetsmetodiken i stora öppna källkods-projekt. " },
               new Course { Name = "C-programmering - Grundkurs", StartDate = DateTime.Now.AddDays(2), Content = "Denna utbildning vänder sig till programmerare och systemerare som ska underhålla befintlig C-programvara. Du får lära dig läsa, förstå, vidare- och nyutveckla C-kod, vad som ger portabilitet respektive icke-portabilitet och ANSI-standardbiblioteket. Du får också en orientering i moderna utvecklingsverktyg." },
               new Course { Name = "C++ Basic Programming", StartDate = DateTime.Now.AddDays(2), Content = "This is the basic C++ course.You will have an introduction to all the basic parts of the quite extensive language C++ as in the 2014 standard. Course focus is on practical use of the language for typical situations, and design in an object oriented way.All theory is applied in hands - on labs where all produced code is platform independent. The course is also IDE independent." },
               new Course { Name = "C++ Advanced Programming", StartDate = DateTime.Now.AddDays(2), Content = "This is the course for experienced C++ programmers with a need to expand their skills into a complete knowledge of the language and new ways to use it for stable, effective and well designed applications. " });

            context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

#if false
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            _addUser(context, userManager, 0);
            context.SaveChanges();
#endif

#if true
            _addUser(context, userManager, 1);
            _addUser(context, userManager, 1);
            _addUser(context, userManager, 1);
            _addUser(context, userManager, 2);
            _addUser(context, userManager, 2);
            _addUser(context, userManager, 3);
            _addUser(context, userManager, 3);
            _addUser(context, userManager, 3);
            _addUser(context, userManager, 3);
            _addUser(context, userManager, 3);
            _addUser(context, userManager, 4);
            _addUser(context, userManager, 4);
            _addUser(context, userManager, 4);
            _addUser(context, userManager, 5);
            _addUser(context, userManager, 5);
            _addUser(context, userManager, 5);
            _addUser(context, userManager, 5);
            _addUser(context, userManager, 6);
            _addUser(context, userManager, 6);
            _addUser(context, userManager, 7);
            _addUser(context, userManager, 7);
            _addUser(context, userManager, 7);
            _addUser(context, userManager, 8);
            _addUser(context, userManager, 8);
            _addUser(context, userManager, 9);
            _addUser(context, userManager, 9);
            _addUser(context, userManager, 9);
#endif
#if true
            _addTeacher(context, userManager, "thomas.teacher@lexiconlms.se", "teacher", "Thomas", "Thomasson");
            _addTeacher(context, userManager, "Peter.Andersson@lexiconlms.se");
            _addTeacher(context, userManager, "Eva.Asp@lexiconlms.se");
            _addTeacher(context, userManager, "t2@x.y", "pppppp", "t2", "t2sson");

            context.SaveChanges();
#endif

#if false
            _addStudent(context, userManager, "Lena.Sten@lexiconlms.se",    courseId: 5);
            _addStudent(context, userManager, "Oscar.Ek@lexiconlms.se",     courseId: 7);
            _addStudent(context, userManager, "Maria.Eklund@lexiconlms.se", courseId: 2);

            context.SaveChanges();
#endif

 
            context.Modules.AddOrUpdate(
                 c => c.Name,
                 new Module { Name = "Bas", StartDate = DateTime.Parse("2010-04-01"), EndDate = DateTime.Parse("2010-04-08"), Description = "Den här modulen är obligatorisk och en förutsättning för vidare studier.", CourseId = 3 });
            context.SaveChanges();

            //activities
            context.Activity.AddOrUpdate(
                c => c.Name,
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Tenta, Name = "Prov", StartDate = DateTime.Parse("2018-04-01"), StartTime = DateTime.Parse("2018-04-01 15:30:00"), EndTime = DateTime.Parse("2018-04-01 17:30:00"), Description = "Årets första test" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Annat, Name = "Kul", StartDate = DateTime.Parse("2018-04-02"), StartTime = DateTime.Parse("2018-04-02 12:30:00"), EndTime = DateTime.Parse("2018-04-02 13:30:00"), Description = "Vi ska hitta på något roligt!" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Föreläsning, Name = "Information", StartDate = DateTime.Parse("2018-04-04"), StartTime = DateTime.Parse("2018-04-04 09:00:00"), EndTime = DateTime.Parse("2018-04-04 09:30:00"), Description = "Information från rektor" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Annat, Name = "Redovisning", StartDate = DateTime.Parse("2018-04-06"), StartTime = DateTime.Parse("2018-04-06 09:30:00"), EndTime = DateTime.Parse("2018-04-06 17:30:00"), Description = "Redovisning" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Annat, Name = "Redovisning 2", StartDate = DateTime.Parse("2018-04-06"), StartTime = DateTime.Parse("2018-04-06 17:30:00"), EndTime = DateTime.Parse("2018-04-06 18:30:00"), Description = "Redovisning 2" });

            context.SaveChanges();
        }
    }
}

