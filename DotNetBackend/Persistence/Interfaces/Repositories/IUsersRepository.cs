using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Entities;

namespace Persistence.Interfaces.Repositories
{
    /// <summary>
    /// Encapsulates the logic required to access <see cref="User"/> related data sources.
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Get a collection of users from the data source.
        /// </summary>
        /// <returns>The users collection.</returns>
        Task<IEnumerable<User>> GetUsers();
    }
}