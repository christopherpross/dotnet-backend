using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Options;

namespace Persistence.OptionsValidation
{
    /// <inheritdoc/>
    public sealed class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private readonly ILogger<DatabaseOptionsValidator> _logger;

        /// <summary>
        /// Creates a new instance of <see cref="DatabaseOptionsValidator"/>.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public DatabaseOptionsValidator(ILogger<DatabaseOptionsValidator> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public ValidateOptionsResult Validate(string name, DatabaseOptions databaseOptions)
        {
            List<string> validationFailures = new List<string>();

            try
            {
                if (string.IsNullOrEmpty(databaseOptions.ConnectionString))
                    throw new ValidationException($"{nameof(databaseOptions.ConnectionString)} is required.");

                _ = new NpgsqlConnectionStringBuilder(databaseOptions.ConnectionString);
            }
            catch (Exception exception)
            {
                validationFailures.Add(exception.Message);
            }

            if (validationFailures.Any())
            {
                string validationFailureErrorMessage = string.Join(Environment.NewLine, validationFailures);

                _logger.LogError(validationFailureErrorMessage);

                return ValidateOptionsResult.Fail(validationFailures);
            }

            return ValidateOptionsResult.Success;
        }
    }
}