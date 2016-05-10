﻿using System;
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

        public int AddCourse(string name)
        {
            db.AddCourse(name);
            return 0;
        }

        public int AddUser(Nullable<int> userRolesId, string userName, string userUserName, string userPassWord, Nullable<int> userSsn, string userEmail)
        {
            db.AddUser(userRolesId, userName, userUserName, userPassWord, userSsn, userEmail);
            return 0;
        }

        public int AddUsersToCourses(Nullable<int> userId, Nullable<int> courseId)
        {
            db.AddUsersToCourses(userId, courseId);
            return 0;
        }

        public int DeleteCourse(string name)
        {
            db.DeleteCourse(name);
            return 0;
        }

        public int DeleteStudent(string name)
        {
            db.DeleteStudent(name);
            return 0;
        }

        public int DeleteTeacher(string name)
        {
            db.DeleteTeacher(name);
            return 0;
        }

        public List<string> GetCourseByName(string courseName)
        {
            var coursesName = db.GetCourseByName(courseName);
            return coursesName.ToList();
        }

        public List<String> GetCourses()
        {
            var course = db.GetCourses();
            return course.ToList();
        }

        public List<string> GetCoursesByUser(string name)
        {
            var courseByUser = db.GetCoursesByUser(name);
            return courseByUser.ToList();
        }

        public List<string> GetRoles()
        {
            var role = db.GetRoles();
            return role.ToList();
        }

        public List<String> GetStudents()
        {
            var Student = db.GetStudents();
            return Student.ToList();
        }

        public List<string> GetTeachers()
        {

            var Teachers = db.GetTeachers();
            return Teachers.ToList();
        }

        // List<GetUserByName_Result>
        public List<string> GetUserByName(string serchName)
        {
            
            var userByName = db.GetUserByName(serchName);

            GetUserByName_Result Res = new GetUserByName_Result();

            Res = userByName.ElementAt(0);

            List<string> Info = Res.ToString().Split(',').ToList<string>();


            return Info;
        }
        

        public int UppdateCourse(string searchName, string name)
        {
            db.UppdateCourse(searchName, name);
            return 0;
        }

        public int UppdateUser(string searchName, Nullable<int> userRolesId, string userName, string userUserName, string userPassWord, Nullable<int> userSsn, string userEmail)
        {
            db.UppdateUser(searchName, userRolesId, userName, userUserName, userPassWord, userSsn, userEmail);
            return 0;
        }

        public int AddAssignment(string courseName, string assignmentName, DateTime dueDate)
        {
            db.AddAssignment(courseName, assignmentName, dueDate);
            return 0;
        }

        public int AddPartAssignment(string assignmentPartName, int assignmentValuePercentage, string assignmentDescription, string assignmentPath, string assignmentName, string assignmentCourse)
        {
            db.AddPartAssignment(assignmentPartName, assignmentValuePercentage, assignmentDescription, assignmentPath, assignmentName, assignmentCourse);
            return 0;
        }

        public int UpdateAssignment(string searchName, string searchCourseName, string updateCourseName, string updateName, DateTime updateDueDate)
        {
            db.UpdateAssignment(searchName, searchCourseName, updateCourseName, updateName, updateDueDate);
            return 0;
        }

        public int UpdatePartAssignment(string searchName, string searchDescription, string updateName, int updatePerCent, string updateDescription, string updatePath)
        {
            db.UpdatePartAssignment(searchName, searchDescription, updateName, updatePerCent, updateDescription, updatePath);
            return 0;
        }

        public int DeleteAssignment(string deleteName, string deleteCourseName)
        {
            db.DeleteAssignment(deleteName, deleteCourseName);
            return 0;
        }

        public int DeletePartAssignment(string deleteName, string deleteDescription)
        {
            db.DeletePartAssignment(deleteName, deleteDescription);
            return 0;
        }

        public int AddSentInAssignments(string userName, string assignmentName, string partAssignmentName, string courseName, string description, string pathToAssinmentName, string pathToAssinmentSaveName)
        {
            db.AddSentInAssigments(userName, assignmentName, partAssignmentName, courseName, description, pathToAssinmentName, pathToAssinmentSaveName);
            return 0;
        }

        /*public List<string> GetAssignments(string getCourseName)
        {
            return 0;
        }*/



    }
}