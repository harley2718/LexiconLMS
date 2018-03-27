using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models.ViewModels
{
    public class UserViewModelWithCourseId
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public int                        CourseId             { get; set; }
        public string                     CourseName           { get; set; }
        public bool                       TeacherListFlag      { get; set; }
        public UserViewModel              DisplayNameContainer { get; set; }
    }
}

