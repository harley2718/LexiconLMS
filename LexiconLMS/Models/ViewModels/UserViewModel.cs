﻿using System;
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
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Email")]
        public string UserEmail { get; set; }
        [DisplayName("Email")]
        public string UserPhoneNumber { get; set; }
    }
 }
