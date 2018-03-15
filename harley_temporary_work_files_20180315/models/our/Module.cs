using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet år inte innehålla mer än 50 tecken.")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Startdatum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("Slutdatum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        public int CourseId { get; set; }

    }
}