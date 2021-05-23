using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IHealthChecksBuilder"/>. 
    /// </summary>
    public static class HealthChecksBuilderExtensions
    {
        /// <summary>
        /// Adds the persistence health checks.
        /// </summary>
        /// <param name="healthChecksBuilder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/>.</returns>
        public static IHealthChecksBuilder AddPersistenceHealthChecks(this IHealthChecksBuilder healthChecksBuilder)
            => healthChecksBuilder.AddDbContextCheck<DatabaseContext>();
    }
}