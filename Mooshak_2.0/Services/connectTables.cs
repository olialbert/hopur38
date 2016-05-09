using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak_2._0.Models;
using System.Data.Entity;
    
namespace Mooshak_2._0.Services
{
    public class connectTables
    {
        private VLN2_2016_H38Entities3 db = new VLN2_2016_H38Entities3();

        public connectTables()
        {
            //_Db = new ApplicationDbContext();
        }

        public List<String> GetCourses()
        {
            
            var course = db.GetCourses();
            return course.ToList();
        }

        public List<String> GetStudents()
        {

            var Student = db.GetStudents();
            return Student.ToList();
        }

        public int AddCourse(string name)
        {
          

            db.AddCourse(name);

            return 0;
        }
    }
}