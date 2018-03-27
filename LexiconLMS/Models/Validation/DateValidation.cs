using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
        public class DateValidation : ValidationAttribute
        {
            //protected override ValidationResult IsValid(DateTime startDate, DateTime endDate, ValidationContext validationContext)
            //{
            //    //DateTime EndDate = Convert.ToDateTime(value);
            //    if ( startDate < endDate)
            //    {
            //        return ValidationResult.Success;
            //    }
            //    else
            //    {
            //        return new ValidationResult
            //            ("Slutdatum kan inte ligga före startdatum.");
            //    }
            //}
        }
    
}