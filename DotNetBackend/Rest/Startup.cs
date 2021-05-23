using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Extensions;
using Rest.Extensions;

namespace Rest
{
    /// <summary>
    /// The class containing the startup methods for the application.
    /// </summary>
    public sealed class Startup
    {
        /// <summary>
        /// Adds services to the DI container.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> holding the services.</param>
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddHealthChecks()
                .AddPersistenceHealthChecks();

            serviceCollection
                .ConfigurePersistenceServices()
                .ConfigureRestServices()
                .AddControllers();
        }

        /// <summary>
        /// Configures the application's request pipeline.
        /// </summary>
        /// <param name="applicationBuilder"><see cref="IApplicationBuilder"/>.</param>
        /// <param name="webHostEnvironment"><see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder
                    .UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(swaggerUiOptions => swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            applicationBuilder
                .UseHealthChecks("/health")
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpointRouteBuilder =>
                {
                    endpointRouteBuilder.MapControllers();
                });
        }
    }
}