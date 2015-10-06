using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDelightful.Validations
{
    public class MaxWordsAttribute:ValidationAttribute
    {
        private int _nbrMotsMax;

        public MaxWordsAttribute(int nbrMotsMax)
        {
            _nbrMotsMax = nbrMotsMax;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value.ToString().Split(' ').Length > _nbrMotsMax)
                {
                    return new ValidationResult("Too many words!");
                }
            }
            return ValidationResult.Success;
        }
    }
}