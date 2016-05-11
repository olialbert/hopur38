using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    public class AssignmentList
    {
        public string AssignmentName { get; set; }
        public List<string> SubAssignments { get; set; }
    }

    public class TeacherViewModelsAssignmetns
    {
        public List<AssignmentList> Assignments { get; set; }
    }
}