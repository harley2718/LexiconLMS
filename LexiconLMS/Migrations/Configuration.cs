namespace LexiconLMS.Migrations
{
    using LexiconLMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            ApplicationUser aUser;
            aUser = userManager.FindByName(userName);
            userManager.AddToRole(aUser.Id, Role.Teacher);
        }

        public static void _addStudent(ApplicationDbContext context,
                                       UserManager<ApplicationUser> userManager,
                                       string email,
                                       string Course    = "kursen kurs",
                                       string password  = "pppppp",
                                       string firstName = "fn placeholder",
                                       string surName   = "en placeholder")
        {
            string userName = email;

            if (context.Users.Any(u => u.UserName == userName))
            {
                return;
            }

            var user = new ApplicationUser { UserName = email, Email = email };
            var result = userManager.Create(user, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            ApplicationUser aUser;
            aUser = userManager.FindByName(userName);
            userManager.AddToRole(aUser.Id, Role.Student);
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { Role.Teacher, Role.Student };
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

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

//            var emails = new[] { "thomas.teacher@lexiconlms.se", "hans.teacher@lexiconlms.se" };

            _addTeacher(context, userManager, "thomas.teacher@lexiconlms.se", "teacher", "Thomas", "Thomasson");
            _addTeacher(context, userManager, "t2@x.y", "pppppp", "t2", "t2sson");
            //_addTeacher(context, userManager, "Thomas.Sv�rd@lexiconlms.se");
            _addTeacher(context, userManager, "Peter.Andersson@lexiconlms.se");
            //_addTeacher(context, userManager, "�sa.Svensson@lexiconlms.se");
            //_addTeacher(context, userManager, "�ke.Larsson@lexiconlms.se");
            _addTeacher(context, userManager, "Eva.Asp@lexiconlms.se");

            context.Courses.AddOrUpdate(
               c => c.Name,
               new Course { Name = "Python 1", StartDate = DateTime.Now.AddDays(2), Description = "Python �r ett programmeringsspr�k som l�ter dig arbeta snabbt och integrera system mer effektivt. Python har vuxit sig extremt starkt p� sista tiden. Idag �r Google, YouTube, Pinterest, DropBox, Instagram med fler skrivna i Python." },
               new Course { Name = "Python 2", StartDate = DateTime.Now.AddDays(2), Description = " Python 2 - Intermediate. This course gives you an introduction to more advanced concepts in the Python language and starts where the course ends." },
               new Course { Name = "C#", StartDate = DateTime.Now.AddDays(2), Description = "This training course teaches developers the programming skills that are required for developers to create applications using the C# language and .NET 4.5. During their five days in the classroom students review the basics of C# program structure, language syntax, and implementation details, and then consolidate their knowledge throughout the week as they build an application that incorporates several features of the .NET Framework 5" },
               new Course { Name = "Java programmering - Grundkurs ", StartDate = DateTime.Now.AddDays(2), Description = "Kursen tar upp s�v�l grundl�ggande syntax som kunskap fr�n Javas viktigaste bibliotek med st�d f�r datalogiska klasser i Collections Framework och nyheterna fr�n Java 8, kommunikation med databaser samt skapande av professionella GUI. Du f�r �ven l�ra dig hur man skriver och k�r enhetstester med ramverket JUnit. Dessutom ing�r introduktion till tr�dprogrammering och f�rpackning och distribution av Java-applikationer." },
               new Course { Name = "Java programmering - Avancerad", StartDate = DateTime.Now.AddDays(2), Description = " Det h�r utbildningen �r f�r dig som vill g� vidare och l�ra dig avancerad Javaprogrammering! Du f�r l�ra dig hur man till�mpar bepr�vade DesignPatterns, olika tekniker f�r att hantera XML-filer, s�v�l f�r konfiguration som f�r lagring av data. Du f�r l�ra dig hur man skriver avancerade multitr�dade applikationer med hj�lp av s�v�l traditionella tr�dklasser som med ramverket Executor Framework." },
               new Course { Name = "GIT kurs", StartDate = DateTime.Now.AddDays(2), Description = "Git �r ett popul�rt, flexibelt, avancerat och �ppet k�llkodsverktyg som �kar teamets produktivitet. GIT �r uppbyggt f�r att passa arbetsmetodiken i stora �ppna k�llkods-projekt. " },
               new Course { Name = "C-programmering - Grundkurs", StartDate = DateTime.Now.AddDays(2), Description = "Denna utbildning v�nder sig till programmerare och systemerare som ska underh�lla befintlig C-programvara. Du f�r l�ra dig l�sa, f�rst�, vidare- och nyutveckla C-kod, vad som ger portabilitet respektive icke-portabilitet och ANSI-standardbiblioteket. Du f�r ocks� en orientering i moderna utvecklingsverktyg." },
               new Course { Name = "C++ Basic Programming", StartDate = DateTime.Now.AddDays(2), Description = "This is the basic C++ course.You will have an introduction to all the basic parts of the quite extensive language C++ as in the 2014 standard. Course focus is on practical use of the language for typical situations, and design in an object oriented way.All theory is applied in hands - on labs where all produced code is platform independent. The course is also IDE independent." },
               new Course { Name = "C++ Advanced Programming", StartDate = DateTime.Now.AddDays(2), Description = "This is the course for experienced C++ programmers with a need to expand their skills into a complete knowledge of the language and new ways to use it for stable, effective and well designed applications. " });

            //_addStudent(context, userManager, "Mia.Str�m@lexiconlms.se", "Python 1");
            _addStudent(context, userManager, "Lena.Sten@lexiconlms.se", "GIT kurs");
            //_addStudent(context, userManager, "Hans.�gren@lexiconlms.se" , "GIT kurs");            
            //_addStudent(context, userManager, "Lars.Bj�rk@lexiconlms.se", "Java programmering - Grundkurs ");
            _addStudent(context, userManager, "Oscar.Ek@lexiconlms.se", "C++ Basic Programming");
            _addStudent(context, userManager, "Maria.Eklund@lexiconlms.se", "C-programmering - Grundkurs");

#if false
            foreach (var email in emails)
            {
                if (context.Users.Any(u => u.UserName == email)) continue;

                // Create user
                var user = new ApplicationUser { UserName = email, Email = email };
                var result = userManager.Create(user, "teacher");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            ApplicationUser aUser;

            // Seeded teacher[s]
            aUser = userManager.FindByName("Thomas.Sv�rd@lexiconlms.se");
            aUser = userManager.FindByName("Peter.Andersson@lexiconlms.se");
            aUser = userManager.FindByName("�sa.Svensson@lexiconlms.se");
            aUser = userManager.FindByName("�ke.Larsson@lexiconlms.se");
            aUser = userManager.FindByName("Eva.Asp@lexiconlms.se");
            userManager.AddToRole(aUser.Id, Role.Teacher);

            // Seeded student[s]
            aUser = userManager.FindByName("Hans.�gren@lexiconlms.se");
            aUser = userManager.FindByName("Lars.Bj�rk@lexiconlms.se");
            aUser = userManager.FindByName("Lena.Sten@lexiconlms.se");
            aUser = userManager.FindByName("Mia.Str�m@lexiconlms.se");
            aUser = userManager.FindByName("Oscar.Ek@lexiconlms.se");
            aUser = userManager.FindByName("Maria.Ekstr�m@lexiconlms.se");
            userManager.AddToRole(aUser.Id, Role.Student);

            context.Courses.AddOrUpdate(
               c => c.Name,
               new Course { Name = "Python 1", StartDate = DateTime.Now.AddDays(2), Description = "Python �r ett programmeringsspr�k som l�ter dig arbeta snabbt och integrera system mer effektivt. Python har vuxit sig extremt starkt p� sista tiden. Idag �r Google, YouTube, Pinterest, DropBox, Instagram med fler skrivna i Python." },
               new Course { Name = "Python 2", StartDate = DateTime.Now.AddDays(2), Description = " Python 2 - Intermediate. This course gives you an introduction to more advanced concepts in the Python language and starts where the course ends." },
               new Course { Name = "C#", StartDate = DateTime.Now.AddDays(2), Description = "This training course teaches developers the programming skills that are required for developers to create applications using the C# language and .NET 4.5. During their five days in the classroom students review the basics of C# program structure, language syntax, and implementation details, and then consolidate their knowledge throughout the week as they build an application that incorporates several features of the .NET Framework 5" },
               new Course { Name = "Java programmering - Grundkurs ", StartDate = DateTime.Now.AddDays(2), Description = "Kursen tar upp s�v�l grundl�ggande syntax som kunskap fr�n Javas viktigaste bibliotek med st�d f�r datalogiska klasser i Collections Framework och nyheterna fr�n Java 8, kommunikation med databaser samt skapande av professionella GUI. Du f�r �ven l�ra dig hur man skriver och k�r enhetstester med ramverket JUnit. Dessutom ing�r introduktion till tr�dprogrammering och f�rpackning och distribution av Java-applikationer." },
               new Course { Name = "Java programmering - Avancerad", StartDate = DateTime.Now.AddDays(2), Description = " Det h�r utbildningen �r f�r dig som vill g� vidare och l�ra dig avancerad Javaprogrammering! Du f�r l�ra dig hur man till�mpar bepr�vade DesignPatterns, olika tekniker f�r att hantera XML-filer, s�v�l f�r konfiguration som f�r lagring av data. Du f�r l�ra dig hur man skriver avancerade multitr�dade applikationer med hj�lp av s�v�l traditionella tr�dklasser som med ramverket Executor Framework." },
               new Course { Name = "GIT kurs", StartDate = DateTime.Now.AddDays(2), Description = "Git �r ett popul�rt, flexibelt, avancerat och �ppet k�llkodsverktyg som �kar teamets produktivitet. GIT �r uppbyggt f�r att passa arbetsmetodiken i stora �ppna k�llkods-projekt. " },
               new Course { Name = "C-programmering - Grundkurs", StartDate = DateTime.Now.AddDays(2), Description = "Denna utbildning v�nder sig till programmerare och systemerare som ska underh�lla befintlig C-programvara. Du f�r l�ra dig l�sa, f�rst�, vidare- och nyutveckla C-kod, vad som ger portabilitet respektive icke-portabilitet och ANSI-standardbiblioteket. Du f�r ocks� en orientering i moderna utvecklingsverktyg." },
               new Course { Name = "C++ Basic Programming", StartDate = DateTime.Now.AddDays(2), Description = "This is the basic C++ course.You will have an introduction to all the basic parts of the quite extensive language C++ as in the 2014 standard. Course focus is on practical use of the language for typical situations, and design in an object oriented way.All theory is applied in hands - on labs where all produced code is platform independent. The course is also IDE independent." },
               new Course { Name = "C++ Advanced Programming", StartDate = DateTime.Now.AddDays(2), Description = "This is the course for experienced C++ programmers with a need to expand their skills into a complete knowledge of the language and new ways to use it for stable, effective and well designed applications. " });
#endif
        }
    }
}

