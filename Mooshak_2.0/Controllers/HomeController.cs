using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak_2._0.Services;

namespace Mooshak_2._0.Controllers
{
    public class HomeController : Controller
    {
        connectTables Tables = new connectTables();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {

            var Courses = Tables.GetStudents();
            return View(Courses);
        }

        public ActionResult About()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "The Courses.";

            return View();
        }
    }
}