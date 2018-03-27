using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    public class Module  : IValidatableObject
    {
        public int Id { get; set; }
        public int ActivityId { get; set; } 
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Fältet får inte innehålla mer än 50 tecken.")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Display(Name = "Startdatum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Slutdatum")]
        [Required(ErrorMessage = "Fältet får inte vara tomt.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        public int CourseId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public virtual Course Course { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return
                new ValidationResult(errorMessage: "Startdatum måste komma före slutdatum.",
                                       memberNames: new[] { "EndDate" });
            }
        }
    }
    

}