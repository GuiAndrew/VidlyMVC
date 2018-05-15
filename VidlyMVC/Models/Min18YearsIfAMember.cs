using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMVC.DTOS;

namespace VidlyMVC.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var customer = (Customer)validationContext.ObjectInstance;
            Customer customer = new Customer();
            if (validationContext.ObjectType == typeof(Customer))
            {
                customer = (Customer)validationContext.ObjectInstance;
            }                
            else
            {
                customer = Mapper.Map((CustomerDto)validationContext.ObjectInstance, customer);
            }                

            //// If customer Id is 0 or 1:
            //// With Magic numbers:
            //if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            //{
            //    return ValidationResult.Success;
            //}
            //// Without Magic numbers:
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            // If customer is null:
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required!");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            
            return (age >= 18) // If age is bigger then or iqual to 18:
                ? ValidationResult.Success // Else will give the following message:
                : new ValidationResult("Customer should be at least" +
                                        "18 years old to go on a membership!");
        }
    }
}