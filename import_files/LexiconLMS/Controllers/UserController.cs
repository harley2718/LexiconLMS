using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LexiconLMS.Models;
using LexiconLMS.Models.ViewModels;

namespace LexiconLMS.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(int? cId)
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserFName,UserLName,UserName,Password,UserEmail,UserPhoneNumber")] UserViewModel user)
        {

            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser
                {
                    FirstName = user.UserFName,
                    LastName = user.UserLName,
                    Email = user.UserEmail,
                    UserName = user.UserName,
                    PasswordHash = user.Password,
                    PhoneNumber = user.UserPhoneNumber
                };
                db.Users.Add(appUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Course", new { id = user.Id});
            }

            return View(user);
        }

        public ActionResult Index()
        {
            var users = db.Users.Select(u => new UserViewModel
            {
                UserFName = u.FirstName,
                UserLName = u.LastName,
                UserEmail = u.Email,
                UserName = u.UserName,
                UserPhoneNumber = u.PhoneNumber
            }
            );
            return View(users);
        }

        //// GET: User
        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //        [Authorize]
        //        public ActionResult Create(int? id)
        //        {
        //#if true
        //            // This controller method represent two different cases:
        //            //   If id is null, then you want a view for adding a teacher,
        //            //   else id.value is a courseId and we want a view for adding
        //            //   a student to that course.
        //            var model = new LexiconLMS.Models.ViewModels.UserViewModel();

        //#if false
        //            model.UserName = "-";
        //            model.UserFName = "-";
        //            model.UserLName = "-";
        //            model.Password = "------";
        //            model.UserEmail = "-";
        //            model.UserPhoneNumber = "-";
        //#endif

        //            model.UserName = "";
        //            model.UserFName = "";
        //            model.UserLName = "";
        //            model.Password = "";
        //            model.UserEmail = "";
        //            model.UserPhoneNumber = "";

        //            if (id == null) {
        //                // Create Teacher.
        //                model.IsTeacher = true;
        //            }
        //            else {
        //                // Create Student.
        //                model.CourseId   = id.Value;
        //                model.CourseName = "kursId_" + model.CourseId.ToString();  // Quick and dirty replacement for real CourseName.
        //                model.IsStudent  = true;
        //            }

        //            return View(model);
        //#endif
        //            return View();


        //#if false
        //            var dataset =
        //                db.Vehicle
        //                .Include(omega => omega.Type)
        //                .Include(omega => omega.Member)
        //                .OrderByDescending(omega => omega.ParkedTime.ToString())
        //                .Select(
        //                    omega => new ParkedVehicleExt01
        //                    {
        //                        Id = omega.Id,
        //                        TypeId = omega.TypeId,
        //                        MemberId = omega.MemberId,
        //                        TypeName = omega.Type.Type,
        //                        MemberName = omega.Member.Name,
        //                        Colour = omega.Colour,
        //                        NumOfWeels = omega.NumOfWeels,
        //                        RegNum = omega.RegNum,
        //                        ParkedTime = omega.ParkedTime,
        //                        CarMake = omega.CarMake,
        //                        Model = omega.Model
        //                    }
        //                );

        //            return View(dataset);

        //            return View(model);
        //            // return View(db.Vehicle);
        //            //return View();
        //#endif
        //#if false
        //        public int Id { get; set; }

        //        public int CourseId      { get; set; }  // Each students should be
        //        public int CourseName    { get; set; }  // associated with a course.
        //        public Boolean IsTeacher { get; set; }  // A couple of booleans can
        //        public Boolean IsStudent { get; set; }  // be used to control variants
        //                                                // of a view.

        //        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        //        [StringLength(20, ErrorMessage = "Fältet år inte innehålla mer än 20 tecken.")]
        //        [DisplayName("Förnamn")]
        //        public string UserFName { get; set; }

        //        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        //        [StringLength(30, ErrorMessage = "Fältet år inte innehålla mer än 30 tecken.")]
        //        [DisplayName("Efternamn")]
        //        public string UserLName { get; set; }

        //        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        //        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        //        [DisplayName("Användarnamn")]
        //        public string UserName { get; set; }

        //        [Required]
        //        [DataType(DataType.Password)]
        //        [Display(Name = "Lösenord")]
        //        public string Password { get; set; }

        //        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        //        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        //        [DisplayName("Email")]
        //        public string UserEmail { get; set; }

        //        [DisplayName("Mobil")]
        //        public string UserPhoneNumber { get; set; }
        //#endif
        //        }

        //#if false
        //        [Authorize]
        //        // GET: Courses/Create
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: Courses/Create
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [Authorize]
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate")] Course course)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Courses.Add(course);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            return View(course);
        //        }
        //#endif

    }
}