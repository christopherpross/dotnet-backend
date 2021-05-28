using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Options;

namespace Persistence.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/>. 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the persistence services.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .ConfigureOptionValidators()
                .ConfigureDatabaseContext();

        /// <summary>
        /// Configures the persistence options.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        private static IServiceCollection ConfigureOptionValidators(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddOptions<DatabaseOptions>()
                .ValidateDataAnnotations();

            return serviceCollection;
        }

        /// <summary>
        /// Configures the database context.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        private static IServiceCollection ConfigureDatabaseContext(this IServiceCollection serviceCollection)
            => serviceCollection.AddDbContext<DatabaseContext>(dbContextOptionsBuilder =>
            {
                ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                IOptionsMonitor<DatabaseOptions> databaseOptionsMonitor = serviceProvider.GetService<IOptionsMonitor<DatabaseOptions>>();
                DatabaseOptions databaseOptions = databaseOptionsMonitor.CurrentValue;

                dbContextOptionsBuilder
                    .UseNpgsql(databaseOptions.ConnectionString)
                    .UseSnakeCaseNamingConvention();
            });
    }
}