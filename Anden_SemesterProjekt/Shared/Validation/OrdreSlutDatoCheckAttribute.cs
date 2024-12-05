using Anden_SemesterProjekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Validation
{
    public class OrdreSlutDatoCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ordre = (Ordre)validationContext.ObjectInstance;

            if (ordre.StartDato.Date > ordre.SlutDato.Date)
            {
                return new ValidationResult("Slutdatoen kan ikke være før startdatoen");
            }

            if (ordre.SlutDato.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Slutdatoen kan ikke være før dags dato");
            }

            return ValidationResult.Success;
        }

    }
}
