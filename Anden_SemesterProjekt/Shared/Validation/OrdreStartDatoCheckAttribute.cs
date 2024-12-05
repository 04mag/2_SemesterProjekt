using Anden_SemesterProjekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Validation
{
    public class OrdreStartDatoCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ordre = (Ordre)validationContext.ObjectInstance;

            if (ordre.StartDato.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Startdatoen kan ikke være før dags dato.");
            }

            return ValidationResult.Success;
        }
    }
}
