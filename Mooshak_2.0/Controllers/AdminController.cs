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
        
        public ActionResult Users()
        {
            var Users = Tables.GetTeachers();
            Users.AddRange(Tables.GetStudents());
            return View(Users);
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
        

        public ActionResult ViewUsersinCourse()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string Name, string Username, string Password, string Ssn, string Email, string Role)
        {
            //vantar course í formið
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.AddUser(RolesId, Name, Username, Password, SsnInt, Email);
            return RedirectToAction("Users");
        }
    }
}