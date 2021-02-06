using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rest
{
    /// <summary>
    /// The entry point class of the application.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// The first method that is invoked.
        /// </summary>
        /// <param name="args">
        /// Each element contains a command-line argument of the current process.
        /// The first element is the executable file name, and the following zero or more elements contain the remaining command-line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        /// <summary>
        /// Sets up the host.
        /// </summary>
        /// <param name="args">
        /// Each element contains a command-line argument of the current process.
        /// The first element is the executable file name, and the following zero or more elements contain the remaining command-line arguments.
        /// </param>
        /// <returns>A new instance of <see cref="IHostBuilder"/>.</returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}