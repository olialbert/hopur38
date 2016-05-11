﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mooshak_2._0
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VLN2_2016_H38Entities3 : DbContext
    {
        public VLN2_2016_H38Entities3()
            : base("name=VLN2_2016_H38Entities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int AddCourse(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddCourse", nameParameter);
        }
    
        public virtual int AddUser(Nullable<int> userRolesId, string userName, string userUserName, string userPassWord, Nullable<int> userSsn, string userEmail)
        {
            var userRolesIdParameter = userRolesId.HasValue ?
                new ObjectParameter("UserRolesId", userRolesId) :
                new ObjectParameter("UserRolesId", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userUserNameParameter = userUserName != null ?
                new ObjectParameter("UserUserName", userUserName) :
                new ObjectParameter("UserUserName", typeof(string));
    
            var userPassWordParameter = userPassWord != null ?
                new ObjectParameter("UserPassWord", userPassWord) :
                new ObjectParameter("UserPassWord", typeof(string));
    
            var userSsnParameter = userSsn.HasValue ?
                new ObjectParameter("UserSsn", userSsn) :
                new ObjectParameter("UserSsn", typeof(int));
    
            var userEmailParameter = userEmail != null ?
                new ObjectParameter("UserEmail", userEmail) :
                new ObjectParameter("UserEmail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", userRolesIdParameter, userNameParameter, userUserNameParameter, userPassWordParameter, userSsnParameter, userEmailParameter);
        }
    
        public virtual int AddUsersToCourses(string userName, string courseName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUsersToCourses", userNameParameter, courseNameParameter);
        }
    
        public virtual int DeleteCourse(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCourse", nameParameter);
        }
    
        public virtual int DeleteStudent(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudent", nameParameter);
        }
    
        public virtual int DeleteTeacher(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTeacher", nameParameter);
        }
    
        public virtual ObjectResult<string> GetCourseByName(string courseName)
        {
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetCourseByName", courseNameParameter);
        }
    
        public virtual ObjectResult<string> GetCourses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetCourses");
        }
    
        public virtual ObjectResult<string> GetCoursesByUser(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetCoursesByUser", nameParameter);
        }
    
        public virtual ObjectResult<string> GetRoles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetRoles");
        }
    
        public virtual ObjectResult<string> GetStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetStudents");
        }
    
        public virtual ObjectResult<string> GetTeachers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetTeachers");
        }
    
        public virtual ObjectResult<GetUserByName_Result> GetUserByName(string serchName)
        {
            var serchNameParameter = serchName != null ?
                new ObjectParameter("SerchName", serchName) :
                new ObjectParameter("SerchName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserByName_Result>("GetUserByName", serchNameParameter);
        }
    
        public virtual int UppdateCourse(string searchName, string name)
        {
            var searchNameParameter = searchName != null ?
                new ObjectParameter("SearchName", searchName) :
                new ObjectParameter("SearchName", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UppdateCourse", searchNameParameter, nameParameter);
        }
    
        public virtual int UppdateUser(string searchName, Nullable<int> userRolesId, string userName, string userUserName, string userPassWord, Nullable<int> userSsn, string userEmail)
        {
            var searchNameParameter = searchName != null ?
                new ObjectParameter("SearchName", searchName) :
                new ObjectParameter("SearchName", typeof(string));
    
            var userRolesIdParameter = userRolesId.HasValue ?
                new ObjectParameter("UserRolesId", userRolesId) :
                new ObjectParameter("UserRolesId", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userUserNameParameter = userUserName != null ?
                new ObjectParameter("UserUserName", userUserName) :
                new ObjectParameter("UserUserName", typeof(string));
    
            var userPassWordParameter = userPassWord != null ?
                new ObjectParameter("UserPassWord", userPassWord) :
                new ObjectParameter("UserPassWord", typeof(string));
    
            var userSsnParameter = userSsn.HasValue ?
                new ObjectParameter("UserSsn", userSsn) :
                new ObjectParameter("UserSsn", typeof(int));
    
            var userEmailParameter = userEmail != null ?
                new ObjectParameter("UserEmail", userEmail) :
                new ObjectParameter("UserEmail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UppdateUser", searchNameParameter, userRolesIdParameter, userNameParameter, userUserNameParameter, userPassWordParameter, userSsnParameter, userEmailParameter);
        }
    
        public virtual int AddAssignment(string courseName, string assignmentName, Nullable<System.DateTime> assignmentDueDate)
        {
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            var assignmentNameParameter = assignmentName != null ?
                new ObjectParameter("AssignmentName", assignmentName) :
                new ObjectParameter("AssignmentName", typeof(string));
    
            var assignmentDueDateParameter = assignmentDueDate.HasValue ?
                new ObjectParameter("AssignmentDueDate", assignmentDueDate) :
                new ObjectParameter("AssignmentDueDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAssignment", courseNameParameter, assignmentNameParameter, assignmentDueDateParameter);
        }
    
        public virtual int AddPartAssignment(string assignmentPartName, Nullable<int> assignmentValuePercentage, string assignmentDescription, string assignmentPath, string assignmentName, string assignmentCourse)
        {
            var assignmentPartNameParameter = assignmentPartName != null ?
                new ObjectParameter("AssignmentPartName", assignmentPartName) :
                new ObjectParameter("AssignmentPartName", typeof(string));
    
            var assignmentValuePercentageParameter = assignmentValuePercentage.HasValue ?
                new ObjectParameter("AssignmentValuePercentage", assignmentValuePercentage) :
                new ObjectParameter("AssignmentValuePercentage", typeof(int));
    
            var assignmentDescriptionParameter = assignmentDescription != null ?
                new ObjectParameter("AssignmentDescription", assignmentDescription) :
                new ObjectParameter("AssignmentDescription", typeof(string));
    
            var assignmentPathParameter = assignmentPath != null ?
                new ObjectParameter("AssignmentPath", assignmentPath) :
                new ObjectParameter("AssignmentPath", typeof(string));
    
            var assignmentNameParameter = assignmentName != null ?
                new ObjectParameter("AssignmentName", assignmentName) :
                new ObjectParameter("AssignmentName", typeof(string));
    
            var assignmentCourseParameter = assignmentCourse != null ?
                new ObjectParameter("AssignmentCourse", assignmentCourse) :
                new ObjectParameter("AssignmentCourse", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddPartAssignment", assignmentPartNameParameter, assignmentValuePercentageParameter, assignmentDescriptionParameter, assignmentPathParameter, assignmentNameParameter, assignmentCourseParameter);
        }
    
        public virtual int AddSentInAssigments(string userName, string assignmentName, string partAssignmentName, string courseName, string description, string pathToAssinmentName, string pathToAssinmentSaveName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var assignmentNameParameter = assignmentName != null ?
                new ObjectParameter("AssignmentName", assignmentName) :
                new ObjectParameter("AssignmentName", typeof(string));
    
            var partAssignmentNameParameter = partAssignmentName != null ?
                new ObjectParameter("PartAssignmentName", partAssignmentName) :
                new ObjectParameter("PartAssignmentName", typeof(string));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var pathToAssinmentNameParameter = pathToAssinmentName != null ?
                new ObjectParameter("PathToAssinmentName", pathToAssinmentName) :
                new ObjectParameter("PathToAssinmentName", typeof(string));
    
            var pathToAssinmentSaveNameParameter = pathToAssinmentSaveName != null ?
                new ObjectParameter("PathToAssinmentSaveName", pathToAssinmentSaveName) :
                new ObjectParameter("PathToAssinmentSaveName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddSentInAssigments", userNameParameter, assignmentNameParameter, partAssignmentNameParameter, courseNameParameter, descriptionParameter, pathToAssinmentNameParameter, pathToAssinmentSaveNameParameter);
        }
    
        public virtual int DeleteAssignment(string deleteName, string deleteCourseName)
        {
            var deleteNameParameter = deleteName != null ?
                new ObjectParameter("DeleteName", deleteName) :
                new ObjectParameter("DeleteName", typeof(string));
    
            var deleteCourseNameParameter = deleteCourseName != null ?
                new ObjectParameter("DeleteCourseName", deleteCourseName) :
                new ObjectParameter("DeleteCourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAssignment", deleteNameParameter, deleteCourseNameParameter);
        }
    
        public virtual int DeletePartAssignment(string deleteName, string deleteDescription)
        {
            var deleteNameParameter = deleteName != null ?
                new ObjectParameter("DeleteName", deleteName) :
                new ObjectParameter("DeleteName", typeof(string));
    
            var deleteDescriptionParameter = deleteDescription != null ?
                new ObjectParameter("DeleteDescription", deleteDescription) :
                new ObjectParameter("DeleteDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePartAssignment", deleteNameParameter, deleteDescriptionParameter);
        }
    
        public virtual ObjectResult<GetAllSubmissionFromStudent_Result> GetAllSubmissionFromStudent(string submissionName, string submissionCourseName, string submissionAssignmentName, string submissionPartAssignmentName)
        {
            var submissionNameParameter = submissionName != null ?
                new ObjectParameter("SubmissionName", submissionName) :
                new ObjectParameter("SubmissionName", typeof(string));
    
            var submissionCourseNameParameter = submissionCourseName != null ?
                new ObjectParameter("SubmissionCourseName", submissionCourseName) :
                new ObjectParameter("SubmissionCourseName", typeof(string));
    
            var submissionAssignmentNameParameter = submissionAssignmentName != null ?
                new ObjectParameter("SubmissionAssignmentName", submissionAssignmentName) :
                new ObjectParameter("SubmissionAssignmentName", typeof(string));
    
            var submissionPartAssignmentNameParameter = submissionPartAssignmentName != null ?
                new ObjectParameter("SubmissionPartAssignmentName", submissionPartAssignmentName) :
                new ObjectParameter("SubmissionPartAssignmentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllSubmissionFromStudent_Result>("GetAllSubmissionFromStudent", submissionNameParameter, submissionCourseNameParameter, submissionAssignmentNameParameter, submissionPartAssignmentNameParameter);
        }
    
        public virtual ObjectResult<string> GetAssignments(string getCourseName)
        {
            var getCourseNameParameter = getCourseName != null ?
                new ObjectParameter("GetCourseName", getCourseName) :
                new ObjectParameter("GetCourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAssignments", getCourseNameParameter);
        }
    
        public virtual ObjectResult<GetBestSubmissionAllStudents_Result> GetBestSubmissionAllStudents(string submissionCourseName, string submissionAssignmentName, string submissionPartAssignmentName)
        {
            var submissionCourseNameParameter = submissionCourseName != null ?
                new ObjectParameter("SubmissionCourseName", submissionCourseName) :
                new ObjectParameter("SubmissionCourseName", typeof(string));
    
            var submissionAssignmentNameParameter = submissionAssignmentName != null ?
                new ObjectParameter("SubmissionAssignmentName", submissionAssignmentName) :
                new ObjectParameter("SubmissionAssignmentName", typeof(string));
    
            var submissionPartAssignmentNameParameter = submissionPartAssignmentName != null ?
                new ObjectParameter("SubmissionPartAssignmentName", submissionPartAssignmentName) :
                new ObjectParameter("SubmissionPartAssignmentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBestSubmissionAllStudents_Result>("GetBestSubmissionAllStudents", submissionCourseNameParameter, submissionAssignmentNameParameter, submissionPartAssignmentNameParameter);
        }
    
        public virtual ObjectResult<GetBestSubmissionForStudent_Result> GetBestSubmissionForStudent(string submissionName, string submissionCourseName, string submissionAssignmentName, string submissionPartAssignmentName)
        {
            var submissionNameParameter = submissionName != null ?
                new ObjectParameter("SubmissionName", submissionName) :
                new ObjectParameter("SubmissionName", typeof(string));
    
            var submissionCourseNameParameter = submissionCourseName != null ?
                new ObjectParameter("SubmissionCourseName", submissionCourseName) :
                new ObjectParameter("SubmissionCourseName", typeof(string));
    
            var submissionAssignmentNameParameter = submissionAssignmentName != null ?
                new ObjectParameter("SubmissionAssignmentName", submissionAssignmentName) :
                new ObjectParameter("SubmissionAssignmentName", typeof(string));
    
            var submissionPartAssignmentNameParameter = submissionPartAssignmentName != null ?
                new ObjectParameter("SubmissionPartAssignmentName", submissionPartAssignmentName) :
                new ObjectParameter("SubmissionPartAssignmentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBestSubmissionForStudent_Result>("GetBestSubmissionForStudent", submissionNameParameter, submissionCourseNameParameter, submissionAssignmentNameParameter, submissionPartAssignmentNameParameter);
        }
    
        public virtual ObjectResult<string> GetPartAssignmentByAssignmentName(string assignmentName, string courseName)
        {
            var assignmentNameParameter = assignmentName != null ?
                new ObjectParameter("AssignmentName", assignmentName) :
                new ObjectParameter("AssignmentName", typeof(string));
    
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetPartAssignmentByAssignmentName", assignmentNameParameter, courseNameParameter);
        }
    
        public virtual int SetGrade(Nullable<int> grade, string fullName)
        {
            var gradeParameter = grade.HasValue ?
                new ObjectParameter("Grade", grade) :
                new ObjectParameter("Grade", typeof(int));
    
            var fullNameParameter = fullName != null ?
                new ObjectParameter("FullName", fullName) :
                new ObjectParameter("FullName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetGrade", gradeParameter, fullNameParameter);
        }
    
        public virtual int UpdateAssignment(string searchName, string searchCourseName, string updateCourseName, string updateName, Nullable<System.DateTime> updateDueDate)
        {
            var searchNameParameter = searchName != null ?
                new ObjectParameter("SearchName", searchName) :
                new ObjectParameter("SearchName", typeof(string));
    
            var searchCourseNameParameter = searchCourseName != null ?
                new ObjectParameter("SearchCourseName", searchCourseName) :
                new ObjectParameter("SearchCourseName", typeof(string));
    
            var updateCourseNameParameter = updateCourseName != null ?
                new ObjectParameter("UpdateCourseName", updateCourseName) :
                new ObjectParameter("UpdateCourseName", typeof(string));
    
            var updateNameParameter = updateName != null ?
                new ObjectParameter("UpdateName", updateName) :
                new ObjectParameter("UpdateName", typeof(string));
    
            var updateDueDateParameter = updateDueDate.HasValue ?
                new ObjectParameter("UpdateDueDate", updateDueDate) :
                new ObjectParameter("UpdateDueDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateAssignment", searchNameParameter, searchCourseNameParameter, updateCourseNameParameter, updateNameParameter, updateDueDateParameter);
        }
    
        public virtual int UpdatePartAssignment(string searchName, string searchDescription, string uppdateName, Nullable<int> uppdatePerCent, string uppdateDescription, string uppdatePath)
        {
            var searchNameParameter = searchName != null ?
                new ObjectParameter("SearchName", searchName) :
                new ObjectParameter("SearchName", typeof(string));
    
            var searchDescriptionParameter = searchDescription != null ?
                new ObjectParameter("SearchDescription", searchDescription) :
                new ObjectParameter("SearchDescription", typeof(string));
    
            var uppdateNameParameter = uppdateName != null ?
                new ObjectParameter("UppdateName", uppdateName) :
                new ObjectParameter("UppdateName", typeof(string));
    
            var uppdatePerCentParameter = uppdatePerCent.HasValue ?
                new ObjectParameter("UppdatePerCent", uppdatePerCent) :
                new ObjectParameter("UppdatePerCent", typeof(int));
    
            var uppdateDescriptionParameter = uppdateDescription != null ?
                new ObjectParameter("UppdateDescription", uppdateDescription) :
                new ObjectParameter("UppdateDescription", typeof(string));
    
            var uppdatePathParameter = uppdatePath != null ?
                new ObjectParameter("UppdatePath", uppdatePath) :
                new ObjectParameter("UppdatePath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePartAssignment", searchNameParameter, searchDescriptionParameter, uppdateNameParameter, uppdatePerCentParameter, uppdateDescriptionParameter, uppdatePathParameter);
        }
    
        public virtual ObjectResult<string> GetStudentsInCoursesByName(string getName)
        {
            var getNameParameter = getName != null ?
                new ObjectParameter("GetName", getName) :
                new ObjectParameter("GetName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetStudentsInCoursesByName", getNameParameter);
        }
    
        public virtual ObjectResult<string> GetTeachersInCoursesByName(string getName)
        {
            var getNameParameter = getName != null ?
                new ObjectParameter("GetName", getName) :
                new ObjectParameter("GetName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetTeachersInCoursesByName", getNameParameter);
        }
    
        public virtual int DeleteUsersToCoursesByUser(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUsersToCoursesByUser", userNameParameter);
        }
    }
}
