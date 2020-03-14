using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVC_WH.App_Code.Attributes
{
    

    public class AttrBirthYearsReg : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (Convert.ToInt32(value) > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Nem jó haver");
        }
    }

    


}