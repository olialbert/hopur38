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
            var viewModel = new ViewUsersInCourseViewModel();
            viewModel.CourseName = "";
            viewModel.Teachers = Tables.GetTeachers();
            viewModel.Students = Tables.GetStudents();

            return View(viewModel);
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

        public ActionResult DeleteCourse(string ID)
        {
            Tables.DeleteCourse(ID);
            return RedirectToAction("Courses");
        }

        public ActionResult ViewUsersinCourse(string ID)
        {


            var viewModel = new ViewUsersInCourseViewModel();
            viewModel.CourseName = ID;
            viewModel.Teachers = Tables.GetTeachersInCoursesByName(ID);
            viewModel.Students = Tables.GetStudentsInCoursesByName(ID);

            return View(viewModel);
        }

        public ActionResult EditUserViewUserInCourse(string ID)
        {
            List <string> Ids = ID.Split(',').ToList<string>();
            var viewModel = new ViewUsersInCourseEditUserViewModel();
            viewModel.CourseName = Ids.ElementAt(1);
            viewModel.UserInfo = Tables.GetUserByName(Ids.ElementAt(0));
            viewModel.Courses = Tables.GetCourses();
            viewModel.UserCourses = Tables.GetCoursesByUser(Ids.ElementAt(0));

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUserViewUserInCourse(string RedirectId,string SearchName, string Name, string Username, string Password, string Ssn, string Email, string Role, string[] Courses)
        {
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.UppdateUser(SearchName, RolesId, Name, Username, Password, SsnInt, Email);
            Tables.DeleteUsersToCoursesByUser(Name);
            if (Courses.Length != 0)
            {
                foreach (var Course in Courses)
                {

                    Tables.AddUsersToCourses(Name, Course);
                }
            }

            return RedirectToAction("ViewUsersinCourse", new { id = RedirectId });
        }

        public ActionResult AddUser()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        [HttpPost]
        public ActionResult AddUser(string Name, string Username, string Password, string Ssn, string Email, string Role, string[] Courses)
        {
            
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.AddUser(RolesId, Name, Username, Password, SsnInt, Email);
            
            foreach(var Course in Courses)
            {
                Tables.AddUsersToCourses(Name, Course);
            }

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
            return RedirectToAction("Courses");
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult EditUser(string ID)
        {
            var viewModel = new EditUserViewModel();
            viewModel.UserInfo = Tables.GetUserByName(ID);
            viewModel.Courses = Tables.GetCourses();
            viewModel.UserCourses = Tables.GetCoursesByUser(ID);
            
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult EditUser(string SearchName, string Name, string Username, string Password, string Ssn, string Email, string Role, string[] Courses)
        {
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.UppdateUser(SearchName, RolesId, Name, Username, Password, SsnInt, Email);
            Tables.DeleteUsersToCoursesByUser(Name);
            if (Courses.Length != 0)
            {
                foreach (var Course in Courses)
                {
                    
                    Tables.AddUsersToCourses(Name, Course);
                }
            }
            
            return RedirectToAction("Users");
        }

        public ActionResult DeleteStudent(string ID)
        {
            Tables.DeleteStudent(ID);
            return RedirectToAction("Users");
        }

        public ActionResult DeleteStudentViewUsersInCourse(string ID)
        {
            List<string> Ids = ID.Split(',').ToList<string>();
            Tables.DeleteStudent(Ids.ElementAt(0));
            return RedirectToAction("ViewUsersinCourse", new { id = Ids.ElementAt(1) });
        }

        public ActionResult DeleteTeacher(string ID)
        {
            Tables.DeleteTeacher(ID);
            return RedirectToAction("Users");
        }

        public ActionResult DeleteTeacherViewUsersInCourse(string ID)
        {
            List<string> Ids = ID.Split(',').ToList<string>();
            Tables.DeleteTeacher(ID);
            return RedirectToAction("ViewUsersinCourse", new { id = Ids.ElementAt(1) });
        }
    }
}