using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ass2.Models
{
    public class ValidDate : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            var e = (Models.Event)validationContext.ObjectInstance;
            DateTime eventFrom = Convert.ToDateTime(value);
            DateTime eventTo = Convert.ToDateTime(e.EventToDateTime);

            if (eventFrom.Date != eventTo.Date)
            {
                return new ValidationResult
                    ("Event-From Date and Event-To Date should be at the same date.");
            }
            else if (eventFrom >= eventTo)
            {
                return new ValidationResult
                    ("Event-From time should be less than Event-To time");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
