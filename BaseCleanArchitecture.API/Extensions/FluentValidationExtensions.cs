using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseCleanArchitecture.API.Extensions
{
    public static class FluentValidationExtensions
    {
        public static ModelStateDictionary ToModelStateDictionary(this ValidationResult result)
        {
            var modelState = new ModelStateDictionary();
            if (result.IsValid)
                return modelState;
            
            foreach (var error in result.Errors)
            {
                var propertyName = error.PropertyName;
                modelState.AddModelError(propertyName, error.ErrorMessage);
            }

            return modelState;
        }
    }
}
