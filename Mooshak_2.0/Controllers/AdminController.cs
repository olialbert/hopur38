﻿using Mooshak_2._0.Services;
using Mooshak_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak_2._0.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        connectTables Tables = new connectTables();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {
            var Courses = Tables.GetCourses();
            return View(Courses);
        }
        
        public ActionResult Users()
        {
            var Teachers = Tables.GetTeachers();
            return View(Teachers);
        }



        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(string Name)
        {
            Tables.AddCourse(Name);
            return RedirectToAction("Courses");
        }

        public ActionResult UpdateCourse()
        {
            return View();
        }

        public ActionResult DeleteCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCourse(string name)
        {
            Tables.DeleteCourse(name);
            return RedirectToAction("Courses");
        }

        public ActionResult ViewUsersinCourse()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string Name, string Username, string Password, string Ssn, string Email, string Role)
        {
            //vantar course í formið
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.AddUser(RolesId, Name, Username, Password, SsnInt, Email);
            return RedirectToAction("Users");
        }

        public ActionResult EditCourse(string ID)
        {
            var Course = Tables.GetCourseByName(ID);
            return View(Course);
        }

        [HttpPost]
        public ActionResult EditCourse(string SearchName, string Name)
        {
            Tables.UppdateCourse(SearchName, Name);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult EditUser(string ID)
        {
            var Users = Tables.GetUserByName(ID);

            return View(Users);

        }

        [HttpPost]
        public ActionResult EditUser(string SearchName, string Name, string Username, string Password, string Ssn, string Email, string Role)
        {
            int RolesId = Convert.ToInt32(Role);
            int SsnInt = Convert.ToInt32(Ssn);
            Tables.UppdateUser(SearchName, RolesId, Name, Username, Password, SsnInt, Email);
            return RedirectToAction("Users");
        }

        public ActionResult DeleteStudent(string ID)
        {
            Tables.DeleteStudent(ID);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeacher(string ID)
        {
            Tables.DeleteTeacher(ID);
            return RedirectToAction("Index");
        }
    }
}