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
            //The below code is unreadable as no body knows what 0 and 1 is
            //It is better to aviod magic number
            //This way code becomes much easier to read and maintain
            //if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
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