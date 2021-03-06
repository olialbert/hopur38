﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak_2._0.Models;
using System.Data.Entity;
    
namespace Mooshak_2._0.Services
{
    //All those functions are used to get a procedure in stored procedures bindings out of the models, connectTable is used to connect the database with the assignment
    public class connectTables
    {
        private VLN2_2016_H38Entities3 db = new VLN2_2016_H38Entities3();

        public connectTables()
        {
            //_Db = new ApplicationDbContext();
        }

        //e. Gets the AddCourse procedure from the database
        public int AddCourse(string name)
        {
            db.AddCourse(name);
            return 0;
        }

        //e. Gets the AddUser procedure from the database
        public int AddUser(Nullable<int> userRolesId, string userName, string userUserName, string userPassWord, Nullable<int> userSsn, string userEmail)
        {
            db.AddUser(userRolesId, userName, userUserName, userPassWord, userSsn, userEmail);
            return 0;
        }

        //e. Gets the AddUserToCourses procedure from the database, all the functions below are used in the same way
        public int AddUsersToCourses(string userName, string courseName)
        {
            db.AddUsersToCourses(userName, courseName);
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

        public int DeleteUsersToCoursesByUser(string name)
        {
            db.DeleteUsersToCoursesByUser(name);
            return 0;
        }

        public List<string> GetAssignments(string courseName)
        {
            var coursesName = db.GetAssignments(courseName);
            return coursesName.ToList();
        }

        public string GetAssignmentDueDates(string courseName, string AssignmentName)
        {
            var DueDate = db.GetAssignmentDueDate(courseName, AssignmentName).FirstOrDefault();
            var date = DueDate.Value.ToString("MM/dd/yy");
            return date;
        }

        public List<GetBestSubmissionAllStudents_Result> GetBestSubmissionAllStudents(string CourseName, string AssignmentName, string PartAssignmentName)
        {
            var listX = db.GetBestSubmissionAllStudents(CourseName, AssignmentName, PartAssignmentName);

            List<GetBestSubmissionAllStudents_Result> Res = new List<GetBestSubmissionAllStudents_Result>();

            foreach (var item in listX.ToList())
            {
                Res.Add(item);
            }

            return Res;
        }

        public List<GetBestSubmissionForStudent_Result> GetBestSubmissionForStudent(string Name,string CourseName, string AssignmentName, string PartAssignmentName)
        {
            var listX = db.GetBestSubmissionForStudent(Name,CourseName, AssignmentName, PartAssignmentName);

            List<GetBestSubmissionForStudent_Result> Res = new List<GetBestSubmissionForStudent_Result>();

            foreach (var item in listX.ToList())
            {
                Res.Add(item);
            }

            return Res;
        }

        public List<GetAllSubmissionFromStudent_Result> GetAllSubmissionFromStudent(string Name,string CourseName, string AssignmentName, string PartAssignmentName)
        {
            var listX = db.GetAllSubmissionFromStudent(Name,CourseName, AssignmentName, PartAssignmentName);

            List<GetAllSubmissionFromStudent_Result> Res = new List<GetAllSubmissionFromStudent_Result>();
            
            foreach (var item in listX.ToList())
            {
                Res.Add(item);
            }

            return Res;
        }

        public string GetName(string UserName, string CourseName)
        {
            var Name = db.GetName(UserName,CourseName).FirstOrDefault();
            return Name;
        }

        public List<string> GetPartAssignmentByAssignmentName(string AssignmentName, string CourseName)
        {
            var PartAssignments = db.GetPartAssignmentByAssignmentName(AssignmentName, CourseName);
            return PartAssignments.ToList();
        }

        public List<string> GetGrades(string UserFullName, string CourseName, string AssignmentName, string SubAssignmmentName)
        {
            var Grades = db.GetAllSubmissionFromStudent(UserFullName, CourseName, AssignmentName, SubAssignmmentName);
            List<string> Res = new List<string>();

            foreach (var Grade in Grades)
            {
                Res.Add(Grade.Grade.ToString());
            }

            return Res;
        }

        public string GetRoleByUser(string UserName, string Password)
        {
            var Role = db.GetRoleByUser(UserName, Password).FirstOrDefault();
            return Role;
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

        public GetPartAssignmentInfoByName_Result GetPartAssignmentInfoByName(string Name, string Desc)
        {
            var list = db.GetPartAssignmentInfoByName(Name, Desc);
            
            GetPartAssignmentInfoByName_Result Result = list.FirstOrDefault();
            return Result;
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

        public List<string> GetStudentsInCoursesByName(string CourseName)
        {
            var role = db.GetStudentsInCoursesByName(CourseName);
            return role.ToList();
        }

        public GetAssignmentxInfoByCourse_Result GetAssignmentInfoByCourse(string CourseName, string AssignmnetName)
        {
            var info = db.GetAssignmentxInfoByCourse(CourseName, AssignmnetName).FirstOrDefault();
            
            return info;
        }

        public List<string> GetAssignmentxInfoByCourse(string CourseName, string AssignmnetName)
        {
            var listX = db.GetAssignmentxInfoByCourse(CourseName, AssignmnetName);

            GetAssignmentxInfoByCourse_Result Res = new GetAssignmentxInfoByCourse_Result();

            Res = listX.ElementAt(0);

            List<string> Info = new List<string>();
            Info.Add(Res.Name);
            Info.Add(Res.DueDate.ToString("yyyy-MM-dd"));
            Info.Add(Res.CourseName);

            return Info;
        }

        public List<string> GetTeachers()
        {
            var Teachers = db.GetTeachers();
            return Teachers.ToList();
        }

        public List<string> GetTeachersInCoursesByName(string CourseName)
        {
            var course = db.GetCourses();      
            var role = db.GetTeachersInCoursesByName(CourseName);
            return role.ToList();
        }

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

        public int SetGrade(int Grade, string Name)
        {
            db.SetGrade(Grade, Name);
            return 0;
        }

        public string GetDescription(string AssignmentName, string SubAssignmentName)
        {
            var Description = db.GetDescription(AssignmentName, SubAssignmentName).ElementAt(0);
            return Description;
        }

        public IEnumerable<GetAllSubmissionFromStudent_Result> GetAllSubmissionsFromStudent(string SubmissionName, string CourseName, string AssignmentName, string PartAssignmentName)
        {
            var AllSubmissions = db.GetAllSubmissionFromStudent(SubmissionName, CourseName, AssignmentName, PartAssignmentName);
            return AllSubmissions;
        }
    }
}