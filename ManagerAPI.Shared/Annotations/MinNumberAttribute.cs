﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    /// <summary>
    /// Minimum number checked annotation
    /// </summary>
    public class MinNumberAttribute : ValidationAttribute
    {
        private int Min { get; set; }

        /// <summary>
        /// Add annotation
        /// </summary>
        /// <param name="min">Min value parameter</param>
        public MinNumberAttribute(int min)
        {
            Min = min;
        }

        /// <summary>
        /// Check current value is valid or not
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                // Try convert to nullable int
                int? number = (int?)value;

                // Ignore null values
                if (number == null)
                {
                    return ValidationResult.Success;
                }

                // Check minimum (explicit)
                if (number < Min)
                {
                    return new ValidationResult($"Value is less than {Min}");
                }
            }
            catch (Exception)
            {
                return new ValidationResult("Field is not integer");
            }

            return ValidationResult.Success;
        }
    }
}