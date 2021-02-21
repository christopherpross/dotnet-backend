using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Persistence.Options;
using Persistence.OptionsValidation;
using Xunit;

namespace Persistence.Tests.UnitTests.OptionsValidationTests
{
    /// <summary>
    /// Provides tests for <see cref="DatabaseOptionsValidator"/>.
    /// </summary>
    public sealed class DatabaseOptionsValidatorTests
    {
        /// <summary>
        /// The instance of <see cref="DatabaseOptionsValidator"/> to test.
        /// </summary>
        private readonly DatabaseOptionsValidator _databaseOptionsValidator;
        
        /// <summary>
        /// The <see cref="ILogger"/> mock implementation.
        /// </summary>
        private readonly Mock<ILogger<DatabaseOptionsValidator>> _loggerMock;
        
        /// <summary>
        /// Creates a new instance of <see cref="DatabaseOptionsValidatorTests"/>.
        /// </summary>
        public DatabaseOptionsValidatorTests()
        {
            _loggerMock = new Mock<ILogger<DatabaseOptionsValidator>>();
            _databaseOptionsValidator = new DatabaseOptionsValidator(_loggerMock.Object);
        }

        /// <summary>
        /// Tests if validation errors are logged on invalid options.
        /// </summary>
        [Fact]
        public void ItLogsErrorsOnceOnValidationFailure()
        {
            DatabaseOptions databaseOptions = new DatabaseOptions();
            _databaseOptionsValidator.Validate(string.Empty, databaseOptions);

            _loggerMock.Verify(logger => logger.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.Is<EventId>(eventId => eventId.Id == 0),
                    It.Is<It.IsAnyType>((@object, @type) => @type.Name == "FormattedLogValues"),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
        
        /// <summary>
        /// Tests if the validation succeeds on valid options.
        /// </summary>
        [Fact]
        public void TheValidateOptionsResultIsSuccessOnSuccessfulValidation()
        {
            DatabaseOptions databaseOptions = new DatabaseOptions()
            {
                ConnectionString = "Host=localhost;Database=db;Username=u;Password=pw"
            };
            ValidateOptionsResult validateOptionsResult = _databaseOptionsValidator.Validate(string.Empty, databaseOptions);

            Assert.True(validateOptionsResult == ValidateOptionsResult.Success);
        }
        
        /// <summary>
        /// Tests if the validation fails on invalid options.
        /// </summary>
        [Fact]
        public void TheValidationFailsOnInvalidOptions()
        {
            DatabaseOptions databaseOptions = new DatabaseOptions();
            ValidateOptionsResult validateOptionsResult = _databaseOptionsValidator.Validate(string.Empty, databaseOptions);
            
            Assert.True(validateOptionsResult.Failed);
        }
    }
}