using System.ComponentModel.DataAnnotations;
using Persistence.ValidationAttributes;

namespace Persistence.Options
{
    /// <summary>
    /// The database options.
    /// </summary>
    public sealed class DatabaseOptions
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        [Required]
        [IsValidDatabaseConnectionString]
        public string ConnectionString { get; set; }
    }
}