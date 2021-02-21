using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence.Options;

namespace Rest.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/>. 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the application's services.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        public static IServiceCollection ConfigureRestServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .ConfigureOptions()
                .ConfigureSwagger();

        /// <summary>
        /// Configures the application's options.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        private static IServiceCollection ConfigureOptions(this IServiceCollection serviceCollection)
        {
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            
            IConfigurationSection persistenceConfigurationSection = configuration.GetSection("Persistence");
            IConfigurationSection databaseConfigurationSection = persistenceConfigurationSection.GetSection("Database");
            serviceCollection.Configure<DatabaseOptions>(databaseConfigurationSection);
        
            return serviceCollection;
        }

        /// <summary>
        /// Configures Swagger.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        /// <returns>The configured services.</returns>
        private static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
            => serviceCollection.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
    }
}