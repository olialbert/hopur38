using Microsoft.Owin;
using Owin;

//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak_2._0.Models;
using System.Data.Entity;
using System.IO;

[assembly: OwinStartupAttribute(typeof(Mooshak_2._0.Startup))]
namespace Mooshak_2._0
{
    
    public partial class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            /*
            VLN2_2016_H38Entities3 db = new VLN2_2016_H38Entities3();
            var course = db.GetCourses();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\\Users\\petur\\Desktop\\testing\test.txt"))
            {
                file.WriteLine("list:");
                foreach (string i in course.ToList())
                    file.WriteLine(i);
            }

              */  
            ConfigureAuth(app);
        }
        
    }
}
