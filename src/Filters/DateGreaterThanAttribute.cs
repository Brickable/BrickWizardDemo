using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WizardDemo.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        string propertyNameToCompare;

        public DateGreaterThanAttribute(string propertyNameToCompare, string errorMessage)
            : base(errorMessage)
        {
            this.propertyNameToCompare = propertyNameToCompare;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.ObjectInstance.GetType().GetProperties()
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                var propertyNameToCompareInfo = validationContext.ObjectType.GetProperty(this.propertyNameToCompare);
               
                if (propertyNameToCompareInfo.PropertyType == typeof(DateTime) ||
                    propertyNameToCompareInfo.PropertyType == typeof(DateTime?))
                {
                    DateTime date;
                    DateTime dateToCompare;
                    object propertyToCompare = propertyNameToCompareInfo.GetValue(validationContext.ObjectInstance, null);

                    if (value != null && propertyToCompare != null)
                    {
                        date = (DateTime) value;
                        dateToCompare = (DateTime) propertyToCompare;
                        if (date.CompareTo(dateToCompare) < 1)
                        {
                            validationResult = new ValidationResult(ErrorMessageString);
                        }
                    }
                    else
                    {
                        //Do nothing, validation will succeed
                    }
                }
                else
                {
                    validationResult = new ValidationResult("PropertyNameToCompare is not a DateTime");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validationResult;
        }

 
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
            dateGreaterThanRule.ErrorMessage = errorMessage;
            dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery validator will use
            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            dateGreaterThanRule.ValidationParameters.Add("propertynametocompare", propertyNameToCompare);

            yield return dateGreaterThanRule;
        }
    }
}