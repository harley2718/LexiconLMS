using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    public class Activity : IValidatableObject
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }

        [DisplayName("Typ")]
        public ActivityType Type { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet får inte innehålla mer än 50 tecken.")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Display(Name = "Datum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Starttid")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DisplayName("Sluttid")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

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

        public virtual Module Module { get; set; }
        public virtual Course Course { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime < StartTime)
            {
                yield return
                new ValidationResult(errorMessage: "Aktivitetens start måste ligga före dess sluttid.",
                                       memberNames: new[] { "EndTime" });
            }
        }

    }


}