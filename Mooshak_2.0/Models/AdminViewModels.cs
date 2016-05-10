using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    public class ViewUsersInCourseViewModels
    {
        public string CourseName {get; set;}
        public List<string> Teachers {get; set;}
        public List<string> Students { get; set; }
    }
}