using Mooshak_2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak_2._0.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher

        connectTables Tables = new connectTables();
        string CourseName ="Forritun";

        public ActionResult _TeacherForm()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View();
        }

        public ActionResult Assignments()
        {
            var Assignments = Tables.GetAssignments(CourseName);
            return View(Assignments);
        }

        public ActionResult AddAssignment()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View(CoursesUsers);
        }

        [HttpPost]
        public ActionResult AddAssignment(string Name, DateTime Date)
        {
            Tables.AddAssignment(CourseName, Name, Date);
            return RedirectToAction("Assignments");

        }
       

        public ActionResult AddSubAssignment()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View(CoursesUsers);
        }

        public ActionResult UpdateDescription()
        {
            return View();
        }

        public ActionResult DeleteAssignment()
        {
            return View();
        }

        public ActionResult ViewSubmittions()
        {
            return View();
        }

        public ActionResult ViewSubmittionsBestFromAllStudents()
        {
            return View();
        }

        public ActionResult DownloadSubmittionsBestFromAllStudents()
        {
            return View();
        }

        public ActionResult ViewSubmittionBestFromStudent()
        {
            return View();
        }

        public ActionResult DownloadSubmittionBestFromStudent()
        {
            return View();
        }

        public ActionResult ViewSubmittionsBestFromAllStudent()
        {
            return View();
        }

        public ActionResult DownloadSubmittionFromUser()
        {
            return View();
        }

    }
}