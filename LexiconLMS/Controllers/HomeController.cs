using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole(LexiconLMS.Models.Role.Teacher))
            {
                // Teacher
                return RedirectToAction("Index", "Courses");
            }
            else if (User.IsInRole(LexiconLMS.Models.Role.Student))
            {
                // Student

                // TODO: Change this when we have a controller to go to.
                return RedirectToAction("Index", "Student");    // Experimental target for early demonstration.
            }

            return View(); // If you hit here, then you will probably stay in signed out state.
        }

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
    }
}