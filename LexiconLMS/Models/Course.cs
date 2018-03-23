using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Kursnamn")]
        public string Name { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [DisplayName("Startdatum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}