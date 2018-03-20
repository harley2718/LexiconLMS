﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using LexiconLMS.Models;
using LexiconLMS.Models.ViewModels;
using System.Net;
using System.Data;
using System.Data.Entity;


namespace LexiconLMS.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //// GET: User
        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // CM_240_G100
        public ActionResult Index(int? id)
        {
            int  courseId        = (id != null) ? id.Value : 0;
            bool teacherListFlag = (courseId == 0);
            bool studentListFlag = (courseId != 0);
            bool teacherRoleFlag = User.IsInRole(Role.Teacher);
            bool studentRoleFlag = User.IsInRole(Role.Student);

            var users =
                db.Users
                .Where(omega => (((omega.CourseId != null) ? omega.CourseId.Value : 0) == courseId))
                .Select(u => new UserViewModel {
                    Id              = u.Id,
                    CourseId        = courseId,
                    UserFName       = u.FirstName,
                    UserLName       = u.LastName,
                    UserEmail       = u.Email,
                    UserName        = u.UserName,
                    UserPhoneNumber = u.PhoneNumber
                });

            var displayNameContainer = new UserViewModel();

            var model = new UserViewModelWithCourseId
            {
                Users                = users,
                DisplayNameContainer = displayNameContainer,
                CourseId             = courseId,
                TeacherListFlag      = teacherListFlag,
                StudentListFlag      = studentListFlag,
                TeacherRoleFlag      = teacherRoleFlag,
                StudentRoleFlag      = studentRoleFlag
            };

            return View(model);
        }

        // CM_240_G110
        [Authorize]
        public ActionResult Create(int? id)
        {
            var courseId = id;

            // This controller method represent two different cases:
            //   If courseId is null, then you want a view for adding a teacher,
            //   else courseId.value is a courseId and we want a view for adding
            //   a student to that course.
            var model = new LexiconLMS.Models.ViewModels.UserViewModel();

            model.UserName        = "";
            model.Password        = "";
            model.UserEmail       = "";
            model.UserFName       = "";
            model.UserLName       = "";
            model.UserPhoneNumber = "";

            if (courseId == null) {
                // Prepare creation of teacher Teacher record.
                model.IsTeacher  = true;
            }
            else {
                // Prepare creation of Student record.
                model.IsStudent  = true;
                model.CourseId   = courseId.Value;
                // TODO get a correct Course Name from database.
                model.CourseName = "kursId_" + model.CourseId.ToString();  // Quick and dirty replacement for real CourseName.
            }

            return View(model);
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // CM_240_P112
        public ActionResult Create([Bind(Include = "IsTeacher,IsStudent,CourseId,UserFName,UserLName,UserName,Password,UserEmail,UserPhoneNumber")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                // var userStore = new UserStore<ApplicationUser>(context);
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var userRef2 = new ApplicationUser { CourseId = user.CourseId, UserName = user.UserName, Email = user.UserEmail, FirstName = user.UserFName, LastName = user.UserLName };
                var result = userManager.Create(userRef2, user.Password);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
                ApplicationUser aUser;
                aUser = userManager.FindByName(user.UserName);
                userManager.AddToRole(aUser.Id, Role.Student);

                // Connect user to course.


                // db.SaveChanges();

                return RedirectToAction("Index", "Course", new { id = user.Id });

            }

            return View(user);
        }

        // GET: User/Edit/5
        // CM_240_G120
        public ActionResult Edit(string id)
        {
            // TODO: Possibly, simplify code using Db.Users.Find(id), to avoid Linq.

            var users = db.Users
                .Where(omega => (omega.Id == id))
                .Select(
                    u => new UserViewModel {
                        Id              = u.Id,
                        CourseId        = (u.CourseId != null) ? (u.CourseId.Value) : 0,
                        UserFName       = u.FirstName,
                        UserLName       = u.LastName,
                        UserEmail       = u.Email,
                        UserName        = u.UserName,
                        Password        = "not being updated",
                        UserPhoneNumber = u.PhoneNumber
                    }
                );

            UserViewModel user = users.ToList()[0];

            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate")] Activity activity)
        //public ActionResult Edit([Bind(Include = "UserFName,UserLName,UserName,Password,UserEmail,UserPhoneNumber")] UserViewModel model)
        // CM_240_P121
        public ActionResult Edit([Bind(Include = "Id,UserFName,UserLName,UserName,Password,UserEmail,UserPhoneNumber")] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(model.Id);

                user.FirstName   = model.UserFName;
                user.LastName    = model.UserLName;
                user.UserName    = model.UserName;
                user.Email       = model.UserEmail;
                user.PhoneNumber = model.UserPhoneNumber;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "User");
            }
            return View(model);
        }
    }
}
