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

            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        public ActionResult Users()
        {

            var Courses = Tables.GetStudents();
            return View(Courses);
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