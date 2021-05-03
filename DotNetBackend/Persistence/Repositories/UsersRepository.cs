using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Interfaces.Repositories;

namespace Persistence.Repositories
{
    /// <inheritdoc/>
    public sealed class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// The database context used as the data source.
        /// </summary>
        private readonly DatabaseContext _databaseContext;

        /// <summary>
        /// Creates a new instance of <see cref="UsersRepository"/>.
        /// </summary>
        /// <param name="databaseContext">The database context used as the data source.</param>
        public UsersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetUsers() => await _databaseContext.Users.ToListAsync();
    }
}