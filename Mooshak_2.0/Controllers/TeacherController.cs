using Mooshak_2._0.Models;
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
        string CourseName = "Forritun";

        public ActionResult _TeacherForm()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View();
        }

        public ActionResult Assignments(string ID)
        {
            var TeacherAssignments = new TeacherViewModelsAssignmetns();
            TeacherAssignments.Courses = Tables.GetCoursesByUser("Jon Jonson");

            var Assignments = Tables.GetAssignments(ID);
            List<AssignmentList> AssignmentList1 = new List<AssignmentList>();
            foreach (var assignment in Assignments)
            {
                var AssignmentList2 = new AssignmentList();
                AssignmentList2.AssignmentName = assignment;
                AssignmentList2.SubAssignments = Tables.GetPartAssignmentByAssignmentName(assignment, ID);
                AssignmentList1.Add(AssignmentList2);
            }
            TeacherAssignments.Assignments = AssignmentList1;
            TeacherAssignments.CurrentClass = ID;
            return View(TeacherAssignments);
        }

        public ActionResult AddAssignment(string ID)
        {
            var ViewModel = new AddAssignmentViewModel();
            var Assignments = Tables.GetCoursesByUser("Jon Jonson");
            ViewModel.Courses = ID;
            ViewModel.Assignments = Assignments;
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult AddAssignment(string CourseHidden, string Name, DateTime Date)
        {
            Tables.AddAssignment(CourseHidden, Name, Date);
            return RedirectToAction("Assignments");

        }


        public ActionResult AddSubAssignment()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View(CoursesUsers);
        }

       /* public ActionResult EditAssignment(string ID)
        {
            var Assignment = Tables.GetAssignmentsInfoByCourse(ID, "Verk1");
            return View(Assignment);
        }*/

        [HttpPost]
        public ActionResult EditAssignment(string searchName, string searchCourseName, string updateName, DateTime updateDueDate)
        {
            Tables.UpdateAssignment(searchName, searchCourseName, searchCourseName, updateName, updateDueDate);
            return RedirectToAction("Assignments");
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