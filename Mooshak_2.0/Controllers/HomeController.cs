using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshak_2._0.Services;

namespace Mooshak_2._0.Controllers
{
    //The HomeController is used to login 
    public class HomeController : Controller
    {
        //So the connectTables can be used
        connectTables Tables = new connectTables();

        //Used to check out what permission the user login in has, redirects the user on the right page depending what role he has in the database
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string UserName, string PassWord)
        {
            var Role = Tables.GetRoleByUser(UserName, PassWord);
            var Name = Tables.GetName(UserName, PassWord);

            if (Role == "Admin")
                return RedirectToAction("Courses", "Admin");
            if (Role == "Teacher")
                return RedirectToAction("Assignments", "Teacher", new {id = "", TeacherId = Name });
            if (Role == "Student")
                return RedirectToAction("Index", "Student", new { id = Name });

            return RedirectToAction("Index");
        }
    }
}