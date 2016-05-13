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
    //The TeacherController uses the connectTables to get and send information to and from the database
    public class TeacherController : Controller
    {
        // GET: Teacher

        connectTables Tables = new connectTables();

        public ActionResult _TeacherForm(string ID,string TeacherID)
        {
            return View();
        }

        //Fetches all the assignments in the database and returns them to the View
        public ActionResult Assignments(string ID, string TeacherID)
        {
            var TeacherAssignments = new TeacherViewModelsAssignmetns();
            TeacherAssignments.Courses = Tables.GetCoursesByUser(TeacherID);
            TeacherAssignments.Name = TeacherID;
            var Assignments = Tables.GetAssignments(ID);
            List<AssignmentList> AssignmentList1 = new List<AssignmentList>();

            foreach (var assignment in Assignments)
            {
                var AssignmentList2 = new AssignmentList();
                AssignmentList2.AssignmentName = assignment;
                AssignmentList2.DueDate = Tables.GetAssignmentDueDates(ID,assignment);
                AssignmentList2.SubAssignments = Tables.GetPartAssignmentByAssignmentName(assignment, ID);
                AssignmentList1.Add(AssignmentList2);
            }

            TeacherAssignments.Assignments = AssignmentList1;
            TeacherAssignments.CurrentClass = ID;
            return View(TeacherAssignments);
        }

        //Sends the View the right course that is about to get assignment added to
        public ActionResult AddAssignment(string ID, string TeacherID)
        {
            var ViewModel = new AddAssignmentViewModel();
            var Assignments = Tables.GetCoursesByUser("Jon Jonson");
            ViewModel.Courses = ID;
            ViewModel.Assignments = Assignments;
            ViewModel.Name = TeacherID;
            return View(ViewModel);
        }

        //Adds an assignment to a selected course through the View
        [HttpPost]
        public ActionResult AddAssignment(string TeacherID,string CourseHidden, string Name, DateTime Date)
        {
            Tables.AddAssignment(CourseHidden, Name, Date);
            return RedirectToAction("Assignments", new { id = CourseHidden, TeacherID = TeacherID });
        }

        //Sends the View the right course and assignment ID so there can be added a subAssignment
        public ActionResult AddSubAssignment(string ID,string courseID, string TeacherID)
        {
            var ViewModel = new TeacherViewModelsAssignmetns();
            ViewModel.CurrentAssignment = ID;
            ViewModel.CurrentClass = courseID;
            ViewModel.Name = TeacherID;
            return View(ViewModel);
        }

        //Gets a new subAssignment through the View that is about to be added to the database
        [HttpPost]
        public ActionResult AddSubAssignment(string TeacherID, string AssignmentName, string CourseName,string SubName,string Descrip, string limit, string Percentage, string Input, string Output)
        {
            int PercentNum = Convert.ToInt32(Percentage);
            Tables.AddPartAssignment(SubName, PercentNum, Descrip, Input, AssignmentName, CourseName);
            return RedirectToAction("Assignments", new { id = CourseName, TeacherID });
        }

        public ActionResult BestSubmittionsFromAllStudents(string ID, string MainID, string CourseId)
        {
            var Submittions = Tables.GetBestSubmissionAllStudents(CourseId, MainID, ID);
            return View(Submittions);
        }

        //Gets best sumbittions from all the students and sends it to the View
        public ActionResult GetSumbittionsViewModel(string ID, string MainID, string CourseId, string TeacherID)
        {
            
            var ViewModel = new GetSumbittionsViewModel();
            ViewModel.Submittions = Tables.GetBestSubmissionAllStudents(CourseId,MainID,ID);
            ViewModel.Name = TeacherID;
            return View(ViewModel);
        }

        //Gets the right Assignment that is about to be edited, sends to the View
        public ActionResult EditAssignment(string ID,string courseID, string TeacherID)
         {
            var ViewModel = new AddAssignmentViewModel();
            ViewModel.Assignments = Tables.GetAssignmentxInfoByCourse(courseID, ID);
            ViewModel.Name = TeacherID;
            return View(ViewModel);
        }
        
        //Gets edited version of an assignment and sends the information forward to be added in the database
        [HttpPost]
        public ActionResult EditAssignment(string TeacherID,string searchName, string searchCourseName, string updateName, DateTime updateDueDate)
        {
            Tables.UpdateAssignment(searchName, searchCourseName, searchCourseName, updateName, updateDueDate);
            return RedirectToAction("Assignments", new { id = searchCourseName , TeacherID  = TeacherID });
        }

        //Gets the right subAssignment that is about to be edited through the View
        public ActionResult EditSubassignment(string subID, string mainID, string TeacherID)
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
            var ViewModel = new EditSubAssignmentViewModel();
            ViewModel.Info = model;
            ViewModel.Name = TeacherID;
            return View(model);
        }

        //Edited subAssignment is fetched through the View and sends it to be added to the database
        [HttpPost]
        public ActionResult EditSubassignment(string TeacherID,string SearchName, string SearchDesc, string SubName, string Descrip, string Percentage, string Input)
        {
            int PercentNum = Convert.ToInt32(Percentage);
            Tables.UpdatePartAssignment(SearchName, SearchDesc, SubName, PercentNum, Descrip, Input);
            return RedirectToAction("Assignments");
        }
        
        //
        public ActionResult UpdateDescription()
        {
            return View();
        }
        
        //Sends information about assignment that is about to be deleted in the database
        public ActionResult DeleteAssignment(string ID, string courseID, string TeacherID)
        {
            Tables.DeleteAssignment(ID, courseID);
            return RedirectToAction("Assignments", new { id = courseID, TeacherID });
        }

        //Sends information about subAssignment that is about to be deleted in the database
        public ActionResult DeleteSubAssignment(string ID, string mainID, string courseID, string TeacherID)
        {
            var description = Tables.GetDescription(mainID, ID);
            Tables.DeletePartAssignment(ID, description);
            return RedirectToAction("Assignments", new { id = courseID, TeacherID });
        }

        //Selectes a student through the View
        public ActionResult SelectStudent(string ID, string MainID, string CourseID, string TeacherID)
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.Students = Tables.GetStudentsInCoursesByName(CourseID);
            viewModel.Name = TeacherID;
            return View(viewModel);
        }


	//Selects all the submissions and sends to the View
        public ActionResult AllSubmissions(string ID, string MainID, string PartAssignmentId, string CourseID, string StudentId, string TeacherID)

        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.StudentName = StudentId;
            viewModel.AllSubmit = Tables.GetAllSubmissionFromStudent(ID, CourseID, MainID, PartAssignmentId);
            viewModel.Name = TeacherID;
            return View(viewModel);
        }


	//Finds the best submission and returns it
        public ActionResult BestSubmission(string ID, string MainID, string PartAssignmentId, string CourseID, string StudentId, string TeacherID)

        
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.StudentName = StudentId;
            viewModel.BestSubmit = Tables.GetBestSubmissionForStudent(ID, CourseID, MainID, PartAssignmentId);
            viewModel.Name = TeacherID;
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