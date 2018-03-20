using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [DisplayName("Typ")]
        public ActivityType Type { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet får inte innehålla mer än 50 tecken.")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Display(Name = "Start")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd H:mm tt}")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DisplayName("Slut")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd H:mm tt}")]
        public DateTime EndDate { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        public enum ActivityType
        {           
            Föreläsning = 1,
            Självstudier = 2,
            Studiebesök = 3,
            Laboration = 4,
            Lektion = 5,
            Tenta = 6,
            Annat = 7
        }
    }
}