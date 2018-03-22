using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    public class HomeController : Controller
    {
        // CM_200_G100
        public ActionResult Index()
        {
            if (!(User.Identity.IsAuthenticated)) {
                // Not logged in.
                return RedirectToAction("Login", "Account");
            }

            //
            // We have only one explicit role, "teacher", for
            // logged in users. If you are a legitimate user
            // of the application and are not a teacher, then
            // you are a student, with current design.
            //
            if (User.IsInRole(LexiconLMS.Models.Role.Teacher)) {
                // Teacher
                return RedirectToAction("Index", "Course");
            } else {
                // Student
                return RedirectToAction("Index", "Student");
            }
        }

#if false
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
#endif
    }
}