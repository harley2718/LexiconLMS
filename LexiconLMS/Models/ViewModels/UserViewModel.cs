using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LexiconLMS.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

#if true
        public int     CourseId   { get; set; }  // Each students should be
        public string  CourseName { get; set; }  // associated with a course.
        public Boolean IsTeacher  { get; set; }  // A couple of booleans can
        public Boolean IsStudent  { get; set; }  // be used to control variants
                                                 // of a view.
#endif

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(20, ErrorMessage = "Fältet år inte innehålla mer än 20 tecken.")]
        [DisplayName("Förnamn")]
        public string UserFName { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(30, ErrorMessage = "Fältet år inte innehålla mer än 30 tecken.")]
        [DisplayName("Efternamn")]
        public string UserLName { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Användarnamn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [DisplayName("Mobil")]
        public string UserPhoneNumber { get; set; }
    }
}
