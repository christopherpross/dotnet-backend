using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    /// <inheritdoc/>
    public sealed class DatabaseContext : DbContext
    {
        /// <summary>
        /// Creates a new instance of <see cref="DatabaseContext"/>.
        /// </summary>
        /// <param name="dbContextOptions">The options to be used by the database context.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        
        /// <summary>
        /// The set of user entities.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}