namespace LexiconLMS.Migrations
{
    using LexiconLMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class SequenceNumberGen
    {
        public static int Number = 0;

        public static int GetNumber()
        {
            LexiconLMS.Migrations.SequenceNumberGen.Number += 1;
            return LexiconLMS.Migrations.SequenceNumberGen.Number;
        }
    }

    public class MySeed
    {
        public static string MyAsciiOnlyFunction(string s)
        {
            var res = "";

            foreach (char c in s)
            {
                if ((c >= 'A') && (c <= 'Z'))
                {
                    res += ((char)((int)c + (int)'a' - (int)'A'));
                }
                else if ((c >= 'a') && (c <= 'z'))
                {
                    res += c;
                }
            }

            return res;
        }

        public static void _AddT(
            ApplicationDbContext ctx,
            UserManager<ApplicationUser> uMan,
            bool t = true,
            string f = "AFirstName",
            string e = "ALastName",
            string u = null,
            int k = 0,
            string p = "Aaaa-0",
            // string m = null,
            string ph = ""
        )
        {
            _AddU(ctx: ctx, uMan: uMan, t: true, f: f, e: e, u: u, k: k, p: p, ph: ph);
        }

        public static void _AddS(
            ApplicationDbContext ctx,
            UserManager<ApplicationUser> uMan,
            bool t = false,
            string f = "AFirstName",
            string e = "ALastName",
            string u = null,
            int k = 0,
            string p = "Aaaa-0",
            // string m = null,
            string ph = ""
        )
        {
            _AddU(ctx: ctx, uMan: uMan, t: false, f: f, e: e, u: u, k: k, p: p, ph: ph);
        }

        public static void _AddU(
            ApplicationDbContext ctx,
            UserManager<ApplicationUser> uMan,
            bool t = false,
            string f = "AFirstName",
            string e = "ALastName",
            string u = null,
            int k = 0,
            string p = "Aaaa-0",
            // string m = null,
            string ph = ""
        )
        {
            int courseId = 0;
            if (!t)
            {
                if (k != 0)
                {
                    courseId = k;
                }
                else
                {
                    var x = SequenceNumberGen.GetNumber();
                    courseId = (((x * x) % 9) + 1);
                }
            }
            var firstName = f;
            var lastName = e;

            string userName;
            if (u == null)
            {
                userName = MyAsciiOnlyFunction(f) + "." + MyAsciiOnlyFunction(e);
            }
            else
            {
                userName = u;
            }

            if (ctx.Users.Any(omega => omega.UserName == userName))
            {
                userName = "user" + SequenceNumberGen.GetNumber().ToString();
            }

            if (userName.IndexOf("@") == -1)
            {
                userName += "@home.se";
            }

            var password = p;

            _addUser(
                ctx,
                uMan,
                courseId:    courseId,
                email:       userName,  // Username used as password when seeding.
                password:    password,
                firstName:   firstName,
                lastName:    lastName,
                userName:    userName,
                phoneNumber: ph
            );
        }

        public static bool _addUser(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    int courseId,
                                    string email       = "e@e.e",
                                    string password    = "Aaaa-0",
                                    string firstName   = "fn2 placeholder",
                                    string lastName    = "en3 placeholder",
                                    string userName    = "u0",
                                    string phoneNumber = ""
        )
        {
            if (context.Users.Any(u => u.UserName == userName))
            {
                return false;
            }

            ApplicationUser user;
            if (courseId == 0)
            {
                user = new ApplicationUser {
                    UserName    = userName,
                    FirstName   = firstName,
                    LastName    = lastName,
                    Email       = email,
                    PhoneNumber = phoneNumber };
            }
            else
            {
                user = new ApplicationUser {
                    UserName    = userName,
                    FirstName   = firstName,
                    LastName    = lastName,
                    Email       = email,
                    PhoneNumber = phoneNumber,
                    CourseId    = courseId };
            }
            var result = userManager.Create(user, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            context.SaveChanges();

            if (courseId == 0)
            {
                ApplicationUser aUser;
                aUser = userManager.FindByName(userName);
                userManager.AddToRole(aUser.Id, Role.Teacher);
                context.SaveChanges();
            }

            return true;
        }

        public static void Seed2(ApplicationDbContext context = null)
        {
            if (context == null)
            {
                context = new ApplicationDbContext();
            }

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
            // var userManager = new UserManager<ApplicationUser>(userStore);
            var uMan = new UserManager<ApplicationUser>(userStore);
            var ctx = context;

            _AddT(ctx, uMan, f: "Thomas",   e: "Thomasson",        u: "thomas.teacher@lexiconlms.se", p: "teacher");
#if true
            _AddT(ctx, uMan, f: "Klas",     e: "Bengtsson",        u: "kb@gmail.com",                 p: "hemLigt123");
            _AddT(ctx, uMan, f: "Per",      e: "Sundman",          u: "per@gmail.com",                p: "hemLigt123");
            _AddT(ctx, uMan, f: "John",     e: "Cleese",           u: "jp@hotmail.com",               p: "hemLigt123");
            _AddT(ctx, uMan, f: "Fröken",   e: "Uhr",                                                                  ph: "+46890510");

            _AddS(ctx, uMan, f: "Eilert",   e: "Lingonsson", k: 3, u: "eillin@gmail.com",             p: "Abc-123");
            _AddS(ctx, uMan, f: "Evert",    e: "Matsson",    k: 3, u: "evert@gmail.com");
            _AddS(ctx, uMan, f: "Erik",     e: "Nilsson",    k: 3, u: "erikn@gmail.com");
            _AddS(ctx, uMan, f: "Erland",   e: "Gustavssom", k: 3, u: "eg@eg.eu",                                      ph: "+4631313131");
            _AddS(ctx, uMan, f: "Gunnar",   e: "Hansson",    k: 3, u: "gh@gh.kz");
#endif

            var fList = new List<string>();
            var eList = new List<string>();

            fList.Add("Adam");
            fList.Add("Bertil");
            fList.Add("Cesar");
            fList.Add("David");
            fList.Add("Erik");
            fList.Add("Filip");
            fList.Add("Gustav");
            fList.Add("Helge");

            eList.Add("Karlsson");
            eList.Add("Larsson");
            eList.Add("Pettersson");
            eList.Add("Andersson");
            eList.Add("Ohlsson");
            eList.Add("Stridh");
            eList.Add("Jansson");
            eList.Add("Johansson");

#if true
            foreach (string f in fList) {
                foreach (string e in eList) {
                    _AddS(ctx, uMan, f: f, e: e);
                }
            }
#endif

            context.Modules.AddOrUpdate(
                 c => c.Name,
                 new Module { Name = "Bas", StartDate = DateTime.Parse("2010-04-01"), EndDate = DateTime.Parse("2010-04-08"), Description = "Den här modulen är obligatorisk och en förutsättning för vidare studier.", CourseId = 1 });
            context.SaveChanges();

            //activities
            context.Activity.AddOrUpdate(
                c => c.Name,
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Tenta, Name = "Prov", StartDate = DateTime.Parse("2018-04-01"), StartTime = DateTime.Parse("2018-04-01 15:30:00"), EndTime = DateTime.Parse("2018-04-01 17:30:00"), Description = "Årets första test" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Annat, Name = "Kul", StartDate = DateTime.Parse("2018-04-02"), StartTime = DateTime.Parse("2018-04-02 12:30:00"), EndTime = DateTime.Parse("2018-04-02 13:30:00"), Description = "Vi ska hitta på något roligt!" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Föreläsning, Name = "Information", StartDate = DateTime.Parse("2018-04-04"), StartTime = DateTime.Parse("2018-04-04 09:00:00"), EndTime = DateTime.Parse("2018-04-04 09:30:00"), Description = "Information från rektor" },
                new Activity { ModuleId = 1, Type = Activity.ActivityType.Annat, Name = "Redovisning", StartDate = DateTime.Parse("2018-04-06"), StartTime = DateTime.Parse("2018-04-06 09:30:00"), EndTime = DateTime.Parse("2018-04-06 17:30:00"), Description = "Redovisning" });

            context.SaveChanges();
        }

    }

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            LexiconLMS.Migrations.MySeed.Seed2(context);
        }
    }
}

