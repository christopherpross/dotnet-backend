using Persistence.ValidationAttributes;
using Xunit;

namespace Persistence.Tests.UnitTests.ValidationAttributeTests
{
    /// <summary>
    /// Provides tests for <see cref="IsValidDatabaseConnectionString"/>.
    /// </summary>
    public sealed class IsValidDatabaseConnectionStringTests
    {
        /// <summary>
        /// Tests the validation, it should pass with valid database connection strings and fail with invalid ones.
        /// </summary>
        /// <param name="expectedToBeValid">The database connection string should be valid.</param>
        /// <param name="databaseConnectionString">The database connection string to validate.</param>
        [Theory]
        [InlineData(true, "Host=localhost;Database=db;Username=u;Password=pw")]
        [InlineData(true, null)]
        [InlineData(true, "")]
        [InlineData(false, "cr ap")]
        public void ItPassesWithValidDatabaseConnectionString(bool expectedToBeValid, object databaseConnectionString)
        {
            IsValidDatabaseConnectionString isValidDatabaseConnectionString = new IsValidDatabaseConnectionString();
            bool validationPassed = isValidDatabaseConnectionString.IsValid(databaseConnectionString);
            
            Assert.Equal(expectedToBeValid, validationPassed);
        }
    }
}