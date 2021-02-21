using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Repositories;
using Xunit;

namespace Persistence.Tests.UnitTests.RepositoryTests
{
    /// <summary>
    /// Provides tests for <see cref="UsersRepository"/>.
    /// </summary>
    public sealed class UsersRepositoryTests : IAsyncLifetime
    {
        /// <summary>
        /// Mock users.
        /// </summary>
        private readonly IEnumerable<User> _mockUsers = new[]
        {
            new User()
            {
                Email = "example@domain.com"
            },
            new User()
            {
                Email = "another_example@domain.com"
            }
        };
        
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly DatabaseContext _databaseContext;
        
        /// <summary>
        /// The instance of <see cref="UsersRepository"/> to test.
        /// </summary>
        private readonly UsersRepository _usersRepository;
        
        /// <summary>
        /// Creates a new instance of <see cref="UsersRepositoryTests"/>.
        /// </summary>
        public UsersRepositoryTests()
        {
            string databaseName = Guid.NewGuid().ToString();
            DbContextOptions<DatabaseContext> dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
            _databaseContext = new DatabaseContext(dbContextOptions);
            _usersRepository = new UsersRepository(_databaseContext);
        }
        
        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            await _databaseContext.Users.AddRangeAsync(_mockUsers);
            await _databaseContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DisposeAsync()
        {
            await _databaseContext.Database.EnsureDeletedAsync();
            await _databaseContext.DisposeAsync();
        }

        /// <summary>
        /// Tests if all users are returned.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        [Fact]
        public async Task ItReturnsAllUsers()
        {
            IEnumerable<User> usersFromDatabase = await _usersRepository.GetUsers();

            int userAmountFromSeedData = _mockUsers.Count();
            int userAmountFromDatabase = usersFromDatabase.Count();
            
            Assert.True(userAmountFromSeedData == userAmountFromDatabase);
        }
    }
}