using Mooshak_2._0.Services;
using Mooshak_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak_2._0.Controllers
{
    public class StudentController : Controller
    {
        connectTables Tables = new connectTables();
        StudentsViewModel Student = new StudentsViewModel();
        string Name = "gummi ben";
        string CourseName = "Gagnaskipann";
        string AssignmentName = "Verk1";

        public void SetCourseVal(string val)
        {
            CourseName = val;
        }

        // GET: Student
        public ActionResult Index(string courseName)
        {
            var ViewStudentModel = new StudentIdsViewModel();
            ViewStudentModel.Assignments = Tables.GetAssignments("prump");
            var Courses = Tables.GetCoursesByUser(Name);
            return View(Courses);
        }

        public ActionResult SelectAssignments(string ID)
        {
            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = ID;

            ViewModel.Assignments = Tables.GetAssignments(ID);
            return View(ViewModel);
        }

        public ActionResult SelectSubAssignment(string subID, string mainID, string courseID, string studentID)
        {
            studentID = "gummi ben";

            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = courseID;
            ViewModel.AssignmentName = mainID;
            ViewModel.SubAssignmentName = subID;
            ViewModel.Submissions = Tables.GetAllSubmissionsFromStudent(studentID, courseID, mainID, subID);

            ViewModel.Assignments = Tables.GetAssignments(courseID);
            ViewModel.SubAssignments = Tables.GetPartAssignmentByAssignmentName(mainID, courseID);
            return View(ViewModel);
        }

        public ActionResult SelectSubmittions(string ID)
        {
            List<string> Ids = ID.Split(',').ToList<string>();
            var courses = Tables.GetPartAssignmentByAssignmentName("Verk1", CourseName);

            var ValueCourse = new List<string>();

            foreach(var course in courses)
            {
                string val = course + "," + Ids.ElementAt(1) + "," + Ids.ElementAt(2);
                ValueCourse.Add(val);
            }

            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = Ids.ElementAt(1);
            ViewModel.AssignmentName = Ids.ElementAt(2);
            ViewModel.SubAssignmentName = Ids.ElementAt(0);
            ViewModel.UberString = ViewModel.AssignmentName + "," + ViewModel.SubAssignmentName + "," + ViewModel.CourseName;
            ViewModel.Submittions = Tables.GetGrades(Name, Ids.ElementAt(1), Ids.ElementAt(2), Ids.ElementAt(0));
            ViewModel.SubAssignments = ValueCourse;
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult SelectSubmittions(string ids,string path)
        {
            List<string> Ids = ids.Split(',').ToList<string>();
            string CourseName = Ids.ElementAt(2);
            string AssignmentName = Ids.ElementAt(0);
            string SubAssignmentName = Ids.ElementAt(1);
            var Description = Tables.GetDescription(Ids.ElementAt(0), Ids.ElementAt(1));
            Tables.AddSentInAssignments(Name, Ids.ElementAt(0), Ids.ElementAt(1), Ids.ElementAt(2), Description, "//",path);
            Tables.SetGrade(58, Name);
            string OldId = SubAssignmentName + "," + CourseName + "," + AssignmentName;
            return RedirectToAction("SelectSubmittions", new { id = OldId });
        }

        public ActionResult DropDown ()
        {
            var courses = Tables.GetPartAssignmentByAssignmentName("Verk1", CourseName);
            return View(courses);

        }

        public ActionResult SubmitAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAssignment(string path)
        {
            Tables.AddSentInAssignments(Name,"Verk1","a",CourseName, "pdf","//",path);
            Tables.SetGrade(54, Name);
            return RedirectToAction("Index");
        }

        public ActionResult ViewDescription(string ID)
        {
            
            List<string> Ids = ID.Split(',').ToList<string>();

            string CourseName = Ids.ElementAt(2);
            string AssignmentName = Ids.ElementAt(0);
            string SubAssignmentName = Ids.ElementAt(1);

            string OldId = SubAssignmentName + "," + CourseName + "," + AssignmentName;
            var Description = Tables.GetDescription(AssignmentName, SubAssignmentName);
            var ViewModel = new StudentsViewModel();
            ViewModel.Description = Description;
            ViewModel.Ids = OldId;
            return View(ViewModel);
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        public ActionResult SeeDescription()
        {
            return View();
        }

        public ActionResult SubmitFile()
        {
            return View();
        }

        public ActionResult ViewMySolutions(string ID)
        {
            var ViewModel = new ViewMySolutionsViewModel();
            ViewModel.CurrentFile = "";
            ViewModel.CurrentSubAssignment = "Select Subassignment";
            ViewModel.SubAssignments = Tables.GetPartAssignmentByAssignmentName(ID,CourseName);
            ViewModel.Grades = Tables.GetGrades(Name, CourseName, ID, "");
            return View();
        }
    }
}