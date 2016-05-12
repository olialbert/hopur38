using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    public class ViewMySolutionsViewModel
    {
        public string CurrentFile { get; set; }
        public string CurrentSubAssignment { get; set; }
        public List<string> SubAssignments { get; set; }
        public List<string> Grades { get; set; }
    }

    public class StudentsViewModel
    {
        public string Description { get; set; }
        public string Ids { get; set; }
    }

    public class StudentIdsViewModel
    {
        public string CourseName { get; set; }
        public string AssignmentName { get; set; }
        public string SubAssignmentName { get; set; }
        public string UberString { get; set; }
        public List<string> Assignments { get; set; }
        public List<string> SubAssignments { get; set; }
        public List<string> Submittions { get; set; }
        public List<string> Courses { get; set; }
        public string StudentName { get; set; }
    }    
}