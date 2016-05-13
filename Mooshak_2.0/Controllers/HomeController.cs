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

        [HttpPost]
        public ActionResult Index(string UserName, string PassWord)
        {

            var Role = Tables.GetRoleByUser(UserName, PassWord);
            var Name = Tables.GetName(UserName, PassWord);

            if (Role == "Admin")
                return RedirectToAction("Courses", "Admin");
            if (Role == "Teacher")
                return RedirectToAction("Assignments", "Teacher");
            if (Role == "Student")
                return RedirectToAction("Index", "Student", new { id = Name });

            return RedirectToAction("Index");
        }

        public ActionResult Users()
        {

            var Courses = Tables.GetStudents();
            return View(Courses);
        }

        public ActionResult Admin()
        {
            var Courses = Tables.GetCourses();
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

        public ActionResult AddCourse()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCourse(string Name)
        {
            Tables.AddCourse(Name);
            return RedirectToAction("Index");
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
            Tables.AddUser(RolesId, Name, Username,Password, SsnInt, Email);
            return RedirectToAction("Users");
        }
        
        public ActionResult EditCourse(string ID)
        {
            var Course = Tables.GetCourseByName(ID);
            return View(Course);
        }

        [HttpPost]
        public ActionResult EditCourse(string SearchName, string Name)
        {
            Tables.UppdateCourse(SearchName, Name);
            return RedirectToAction("Index");
        }

        public ActionResult EditUser(string ID)
        {
            var Users = Tables.GetUserByName(ID);
            
             return View(Users);
            
        }

        [HttpPost]
        public ActionResult EditUser(string SearchName, string Name, string Username, string Password, string Ssn, string Email, string Role)
        {
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.UppdateUser(SearchName, RolesId, Name, Username, Password, SsnInt, Email);
            return RedirectToAction("Users");
        }

        public ActionResult DeleteCourse(string ID)
        {
            Tables.DeleteCourse(ID);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(string ID)
        {
            Tables.DeleteStudent(ID);
            return RedirectToAction("Users");
        }
    }
}