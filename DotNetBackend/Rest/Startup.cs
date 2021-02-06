using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            serviceCollection.AddControllers();
            serviceCollection.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
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