using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    //Customer Validation
    public class Min18YearIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is Required.");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer Should be at least 18 years old to go on a membership.");
            }

            //same
            //return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer Should be at least 18 years old to go on a membership.");
        }
    }
}