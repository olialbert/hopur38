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
        //string CourseName = "Gagnaskipann";
        /*
        public void SetCourseVal(string val)
        {
            CourseName = val;
        }
        */

        // GET: Student
        public ActionResult Index(string ID)
        {
            var ViewStudentModel = new StudentIdsViewModel();
            ViewStudentModel.Courses = Tables.GetCoursesByUser(ID);
            ViewStudentModel.Assignments = Tables.GetAssignments(ViewStudentModel.Courses.FirstOrDefault());
            ViewStudentModel.StudentName = ID;
            return View(ViewStudentModel);
        }

        public ActionResult SelectAssignments(string ID, string studentID)
        {
            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = ID;
            ViewModel.Assignments = Tables.GetAssignments(ID);
            ViewModel.Courses = Tables.GetCoursesByUser(studentID);
            ViewModel.StudentName = studentID;
            return View(ViewModel);
        }

        public ActionResult SelectSubAssignment(string subID, string mainID, string courseID, string studentID)
        {
            var ViewModel = new StudentIdsViewModel();
            ViewModel.StudentName = studentID;
            ViewModel.CourseName = courseID;
            ViewModel.AssignmentName = mainID;
            ViewModel.SubAssignmentName = subID;

            ViewModel.Assignments = Tables.GetAssignments(courseID);
            ViewModel.SubAssignments = Tables.GetPartAssignmentByAssignmentName(mainID, courseID);
            ViewModel.Submissions = Tables.GetAllSubmissionsFromStudent(studentID, courseID, mainID, subID);

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult SelectSubAssignment(string subID, string mainID, string courseID, string studentID, string path)
        {
            

            string Description = Tables.GetDescription(mainID, subID);
            Tables.AddSentInAssignments(studentID, mainID, subID, courseID, Description, "//", path);
            Tables.SetGrade(58, studentID);
            return RedirectToAction("SelectSubAssignment", new {id = mainID,subID = subID, mainID = mainID, courseID = courseID, studentID = studentID });
        }

        /*
        public ActionResult SelectSubmittions(string ID, string studentID)
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
            ViewModel.StudentName = studentID;
            ViewModel.CourseName = Ids.ElementAt(1);
            ViewModel.AssignmentName = Ids.ElementAt(2);
            ViewModel.SubAssignmentName = Ids.ElementAt(0);
            ViewModel.UberString = ViewModel.AssignmentName + "," + ViewModel.SubAssignmentName + "," + ViewModel.CourseName;
            ViewModel.Submittions = Tables.GetGrades(studentID, Ids.ElementAt(1), Ids.ElementAt(2), Ids.ElementAt(0));
            ViewModel.SubAssignments = ValueCourse;
            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult SelectSubmittions(string studentId,string ids,string path)
        {
            List<string> Ids = ids.Split(',').ToList<string>();
            string CourseName = Ids.ElementAt(2);
            string AssignmentName = Ids.ElementAt(0);
            string SubAssignmentName = Ids.ElementAt(1);
            var Description = Tables.GetDescription(Ids.ElementAt(0), Ids.ElementAt(1));
            
            Tables.SetGrade(58, studentId);
            string OldId = SubAssignmentName + "," + CourseName + "," + AssignmentName;
            return RedirectToAction("SelectSubmittions", new { id = OldId });
        }
        */
                
        public ActionResult ViewDescription(string subID, string mainID, string courseID, string studentID)
        {
            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = courseID;
            ViewModel.AssignmentName = mainID;
            ViewModel.SubAssignmentName = subID;
            ViewModel.StudentName = studentID;

            ViewModel.Description = Tables.GetDescription(mainID, subID);
            ViewModel.Assignments = Tables.GetAssignments(courseID);
            return View(ViewModel);
        }

        public ActionResult ViewSubmission(string subID, string mainID, string courseID, string studentID)
        {
            var ViewModel = new StudentIdsViewModel();
            ViewModel.CourseName = courseID;
            ViewModel.AssignmentName = mainID;
            ViewModel.SubAssignmentName = subID;
            ViewModel.StudentName = studentID;
            ViewModel.Assignments = Tables.GetAssignments(courseID);
            return View(ViewModel);
        }
    }
}