using Mooshak_2._0.Services;
using Mooshak_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak_2._0.Controllers
{
    //The AdminController uses the connectTables to get and send information to and from the database
    public class AdminController : Controller
    {
        //So the connectTables can be used
        connectTables Tables = new connectTables();

        //Gets courses from the database using the connectTables and returns them to the View so they can be used
        public ActionResult Courses()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }
        
        //Gets both the teachers and students from the database using the connectTables, then returns it to the View
        public ActionResult Users()
        {
            var viewModel = new ViewUsersInCourseViewModel();
            viewModel.CourseName = "";
            viewModel.Teachers = Tables.GetTeachers();
            viewModel.Students = Tables.GetStudents();

            return View(viewModel);
        }

        //Gets all the courses
        public ActionResult AddCourse()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        //Used to add a course to the database through the view and the connectTable, redirects you to the "Courses" View afterwards 
        [HttpPost]
        public ActionResult AddCourse(string Name)
        {
            Tables.AddCourse(Name);
            return RedirectToAction("Courses");
        }

        //Deletes a course via the ID, redirects the user back to the right place in the View
        public ActionResult DeleteCourse(string ID)
        {
            Tables.DeleteCourse(ID);
            return RedirectToAction("Courses");
        }

        //Gets all the users in one singular course, both the teachers and students, from the user table in the database using stored procedure and the connectTable and returns them to the View
        public ActionResult ViewUsersinCourse(string ID)
        {
            var viewModel = new ViewUsersInCourseViewModel();
            viewModel.CourseName = ID;
            viewModel.Teachers = Tables.GetTeachersInCoursesByName(ID);
            viewModel.Students = Tables.GetStudentsInCoursesByName(ID);

            return View(viewModel);
        }

        //So it's possible to edit/view a user in a special course from the database, the View can then use it
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

        //Takes edited information about the the user and sends it to the database adds the user in a new course if needed 
        [HttpPost]
        public ActionResult EditUserViewUserInCourse(string RedirectId, string SearchName, string Name, string Username, string Password, string Ssn, string Email, string Role, string[] Courses)
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

        //Fetches what course the user is gonna be signed to, using the connectTable
        public ActionResult AddUser()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }

        //Adds a new user to the database from the View 
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

        //Fetches the right course name using the ID and returns it
        public ActionResult EditCourse(string ID)
        {
            var Course = Tables.GetCourseByName(ID);
            return View(Course);
        }

        //Updates a course from the View that is already in the database
        [HttpPost]
        public ActionResult EditCourse(string SearchName, string Name)
        {
            Tables.UppdateCourse(SearchName, Name);
            return RedirectToAction("Courses");
        }

        //Selects the right user from the View so it can be edited 
        public ActionResult EditUser(string ID)
        {
            var viewModel = new EditUserViewModel();
            viewModel.UserInfo = Tables.GetUserByName(ID);
            viewModel.Courses = Tables.GetCourses();
            viewModel.UserCourses = Tables.GetCoursesByUser(ID);
            
            return View(viewModel);
        }

        //Gets the information that need to be changed from the View and adds them to the database using the connectTable
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

        //Delets a student that the user selected from the database using a stored procedure
        public ActionResult DeleteStudent(string ID)
        {
            Tables.DeleteStudent(ID);
            return RedirectToAction("Users");
        }

        //Delets a student that the user selected from the database using a stored procedure, redirects to a different place
        public ActionResult DeleteStudentViewUsersInCourse(string ID)
        {
            List<string> Ids = ID.Split(',').ToList<string>();
            Tables.DeleteStudent(Ids.ElementAt(0));
            return RedirectToAction("ViewUsersinCourse", new { id = Ids.ElementAt(1) });
        }
        
        //Delets a teacher that the user selected from the database using a stored procedure 
        public ActionResult DeleteTeacher(string ID)
        {
            Tables.DeleteTeacher(ID);
            return RedirectToAction("Users");
        }

        //Delets a teacher that the user selected from the database using a stored procedure, redirects to a different place in the View
        public ActionResult DeleteTeacherViewUsersInCourse(string ID)
        {
            List<string> Ids = ID.Split(',').ToList<string>();
            Tables.DeleteTeacher(ID);
            return RedirectToAction("ViewUsersinCourse", new { id = Ids.ElementAt(1) });
        }
    }
}