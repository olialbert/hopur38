using Mooshak_2._0.Services;
using Mooshak_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak_2._0.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        connectTables Tables = new connectTables();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(string Name)
        {
            Tables.AddCourse(Name);
            return RedirectToAction("Courses");
        }

        public ActionResult UpdateCourse()
        {
            return View();
        }

        public ActionResult DeleteCourse()
        {
            return View();
        }

        public ActionResult ViewUsersinCourse()
        {
            return View();
        }

        public ActionResult Adduser()
        {
            return View();
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult DeleteUser()
        {
            return View();
        }
    }
}