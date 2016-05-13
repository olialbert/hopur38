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

        /*public ActionResult _TeacherForm()
        {
            var CoursesUsers = Tables.GetCoursesByUser("Jon Jonson");
            return View();
        }*/

        //Fetches all the assignments in the database and returns them to the View
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
                AssignmentList2.DueDate = Tables.GetAssignmentDueDates(ID,assignment);
                AssignmentList2.SubAssignments = Tables.GetPartAssignmentByAssignmentName(assignment, ID);
                AssignmentList1.Add(AssignmentList2);
            }

            TeacherAssignments.Assignments = AssignmentList1;
            TeacherAssignments.CurrentClass = ID;
            return View(TeacherAssignments);
        }

        //Sends the View the right course that is about to get assignment added to
        public ActionResult AddAssignment(string ID)
        {
            var ViewModel = new AddAssignmentViewModel();
            var Assignments = Tables.GetCoursesByUser("Jon Jonson");
            ViewModel.Courses = ID;
            ViewModel.Assignments = Assignments;
            return View(ViewModel);
        }

        //Adds an assignment to a selected course through the View
        [HttpPost]
        public ActionResult AddAssignment(string CourseHidden, string Name, DateTime Date)
        {
            Tables.AddAssignment(CourseHidden, Name, Date);
            return RedirectToAction("Assignments");
        }

        //Sends the View the right course and assignment ID so there can be added a subAssignment
        public ActionResult AddSubAssignment(string ID,string courseID)
        {
            var ViewModel = new TeacherViewModelsAssignmetns();
            ViewModel.CurrentAssignment = ID;
            ViewModel.CurrentClass = courseID;
            return View(ViewModel);
        }

        //Gets a new subAssignment through the View that is about to be added to the database
        [HttpPost]
        public ActionResult AddSubAssignment(string AssignmentName, string CourseName,string SubName,string Descrip, string limit, string Percentage, string Input, string Output)
        {
            int PercentNum = Convert.ToInt32(Percentage);
            Tables.AddPartAssignment(SubName, PercentNum, Descrip, Input, AssignmentName, CourseName);
            return RedirectToAction("Assignments");
        }

        //Gets best sumbittions from all the students and sends it to the View
        public ActionResult BestSubmittionsFromAllStudents(string ID, string MainID, string CourseId)
        {
            var Submittions = Tables.GetBestSubmissionAllStudents(CourseId,MainID,ID);
            return View(Submittions);
        }

        //Gets the right Assignment that is about to be edited, sends to the View
        public ActionResult EditAssignment(string ID)
         {
            var Assignment = Tables.GetAssignmentxInfoByCourse("Gagnaskipann", ID);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\\Users\\petur\\Desktop\\testing\test.txt"))
            {
                file.WriteLine("list:");
                foreach (string i in Assignment.ToList())
                    file.WriteLine(i);
            }
            return View(Assignment);
        }
        
        //Gets edited version of an assignment and sends the information forward to be added in the database
        [HttpPost]
        public ActionResult EditAssignment(string searchName, string searchCourseName, string updateName, DateTime updateDueDate)
        {
            Tables.UpdateAssignment(searchName, searchCourseName, searchCourseName, updateName, updateDueDate);
            return RedirectToAction("Assignments");
        }

        //Gets the right subAssignment that is about to be edited through the View
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

        //Edited subAssignment is fetched through the View and sends it to be added to the database
        [HttpPost]
        public ActionResult EditSubassignment(string SearchName, string SearchDesc, string SubName, string Descrip, string Percentage, string Input)
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
        public ActionResult DeleteAssignment(string ID, string courseID)
        {
            Tables.DeleteAssignment(ID, courseID);
            return RedirectToAction("Assignments/" + courseID);
        }

        //Sends information about subAssignment that is about to be deleted in the database
        public ActionResult DeleteSubAssignment(string ID, string mainID, string courseID)
        {
            var description = Tables.GetDescription(mainID, ID);
            Tables.DeletePartAssignment(ID, description);
            return RedirectToAction("Assignments/" + courseID);
        }

        //Selectes a student through the View
        public ActionResult SelectStudent(string ID, string MainID, string CourseID)
        {
            var viewModel = new SelectStudentViewModel();
            viewModel.CourseName = CourseID;
            viewModel.AssignmentName = MainID;
            viewModel.PartAssignmentName = ID;
            viewModel.Students = Tables.GetStudentsInCoursesByName(CourseID);
            return View(viewModel);
        }


	//Selects all the submissions and sends to the View
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


	//Finds the best submission and returns it
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