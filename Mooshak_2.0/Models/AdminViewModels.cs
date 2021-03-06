﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    //All of these classes are used to get and set variables, they can be used in the View
    public class ViewUsersInCourseViewModel
    {
        public string CourseName { get; set;}
        public List<string> Teachers { get; set;}
        public List<string> Students { get; set; }
    }

    public class ViewUsersInCourseEditUserViewModel
    {
        public string CourseName { get; set; }
        public List<string> UserInfo { get; set; }
        public List<string> Courses { get; set; }
        public List<string> UserCourses { get; set; }
    }

    public class EditUserViewModel
    {
        public List<string> UserInfo { get; set; }
        public List<string> Courses { get; set; }
        public List<string> UserCourses { get; set; }
    }
}