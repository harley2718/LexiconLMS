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

        public class UserViewModel : IdentityUser
    {
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(20, ErrorMessage = "Fältet år inte innehålla mer än 20 tecken.")]
        [DisplayName("Förnamn")]
        public string uFName { get; set; }
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(30, ErrorMessage = "Fältet år inte innehålla mer än 30 tecken.")]
        [DisplayName("Efternamn")]
        public string uLName { get; set; }
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Användarnamn")]
        public string uName { get; set; }
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Email")]
        public string uEmail { get; set; }
        public string uPhoneNumber { get; set; }
    }
 }
