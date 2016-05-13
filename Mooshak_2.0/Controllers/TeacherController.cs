using Mooshak_2._0.Models;
using Mooshak_2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var Courses = Tables.GetCoursesByUser("Jon Jonson");
            return View(Courses);
        }

        [HttpPost]
        public ActionResult AddSubAssignment(string SubName, string Descrip, string limit, string Percentage, string Input, string Output)
        {
            int PercentNum = Convert.ToInt32(Percentage);
            Tables.AddPartAssignment(SubName, PercentNum, Descrip, Input, "Verk1", "Gagnaskipann");
            return RedirectToAction("Assignments");
        }

        public ActionResult BestSubmittionsFromAllStudents(string ID, string MainID, string CourseId)
        {
            var Submittions = Tables.GetBestSubmissionAllStudents(CourseId,MainID,ID);
            return View(Submittions);
        }

        public ActionResult EditAssignment(string ID)
         {
             var Assignment = Tables.GetAssignmentxInfoByCourse("Gagnaskipann", ID);
             return View(Assignment);
         }

        [HttpPost]
        public ActionResult EditAssignment(string searchName, string searchCourseName, string updateName, DateTime updateDueDate)
        {
            Tables.UpdateAssignment(searchName, searchCourseName, searchCourseName, updateName, updateDueDate);
            return RedirectToAction("Assignments");
        }

        public ActionResult EditSubassignment(string subID, string mainID)
        {
            if (subID == null || mainID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Description = Tables.GetDescription(mainID, subID);
            var Assignment = Tables.GetPartAssignmentInfoByName(subID, Description);
            if (Assignment == null)
            {
                return HttpNotFound();
            }
            var model = new GetPartAssignmentInfoByName_Result();
            Assignment.Description = Description;
            model.Name = Assignment.Name;
            model.Description = Assignment.Description;
            model.ValuePercentage = Assignment.ValuePercentage;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditSubassignment(string SearchName, string SearchDesc, string SubName, string Descrip, string Percentage, string Input)
        {
            int PercentNum = Convert.ToInt32(Percentage);
            Tables.UpdatePartAssignment(SearchName, SearchDesc, SubName, PercentNum, Descrip, Input);
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
            var description = Tables.GetDescription(mainID, ID);
            Tables.DeletePartAssignment(ID, description);
            return RedirectToAction("Assignments/" + courseID);
        }

        public ActionResult SelectStudent(string ID, string MainID, string CourseID)
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.Students = Tables.GetStudentsInCoursesByName(CourseID);
            return View(viewModel);
        }

        public ActionResult AllSubmissions(string ID, string MainID, string PartAssignmentId, string CourseID, string StudentId)
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.StudentName = StudentId;
            viewModel.AllSubmit = Tables.GetAllSubmissionFromStudent(ID, CourseID, MainID, PartAssignmentId);
            return View(viewModel);
        }


        public ActionResult BestSubmission(string ID, string MainID, string PartAssignmentId, string CourseID, string StudentId)
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.StudentName = StudentId;
            viewModel.BestSubmit = Tables.GetBestSubmissionForStudent(ID, CourseID, MainID, PartAssignmentId);
            return View(viewModel);
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