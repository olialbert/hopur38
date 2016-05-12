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

        public ActionResult _TeacherForm(string name)
        {
            var CoursesUsers = Tables.GetCoursesByUser("Lalalalal");
            return View(CoursesUsers);
        }

        public ActionResult Assignments()
        {
            var CoursesUsers = Tables.GetCoursesByUser("johann");
            return View(CoursesUsers);
        }

        public ActionResult AddAssignment()
        {
            return View();
        }

        public ActionResult UpdateDescription()
        {
            return View();
        }
        
        public ActionResult DeleteAssignment(string ID, string courseID)
        {
            Tables.DeleteAssignment(ID, courseID);
            return RedirectToAction("Assignments/" + courseID);
        }

        public ActionResult DeleteSubAssignment(string ID, string mainID, string courseID)
        {
            var description = Tables.GetDescription(mainID, ID).FirstOrDefault();
            Tables.DeletePartAssignment(ID, description);
            return RedirectToAction("Assignments/" + courseID);
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