using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    //All of these classes are used to get and set variables, they can be used in the View
    public class AssignmentList
    {
        public string AssignmentName { get; set; }
        public string DueDate { get; set; }
        public List<string> SubAssignments { get; set; }
    }

    public class TeacherViewModelsAssignmetns
    {
        public List<AssignmentList> Assignments { get; set; }
        public List<string> Courses { get; set; }
        public string CurrentClass { get; set; }
        public string CurrentAssignment { get; set; }
        public string Name { get; set; }
    }

    public class AddAssignmentViewModel
    {
        public List<string> Assignments { get; set; }
        public string Courses { get; set; }
        public string Name { get; set; }
    }

    public class GetSumbittionsViewModel
    {
        public List<GetBestSubmissionAllStudents_Result> Submittions { get; set; }
        public string Name { get; set; }
    }

    public class EditSubAssignmentViewModel
    {
        public GetPartAssignmentInfoByName_Result Info { get; set; }
        public string Name { get; set; }
    }

    public class SelectStudentViewModel
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string AssignmentName { get; set; }
        public string PartAssignmentName { get; set; }
        public string Name { get; set; }
        public List<string> Students { get; set; }
        public List<GetAllSubmissionFromStudent_Result> AllSubmit { get; set; }
        public List<GetBestSubmissionForStudent_Result> BestSubmit { get; set; }
    }
}