using System;
using System.ComponentModel.DataAnnotations;
using Npgsql;

namespace Persistence.ValidationAttributes
{
    /// <summary>
    /// <see cref="ValidationAttribute"/> for database connection strings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class IsValidDatabaseConnectionString : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string databaseConnectionString = value?.ToString() ?? string.Empty;
                
                _ = new NpgsqlConnectionStringBuilder(databaseConnectionString);
            }
            catch (Exception exception)
            {
                return new ValidationResult(exception.Message);
            }
            
            return ValidationResult.Success;
        }
    }
}