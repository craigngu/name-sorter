using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace NameSorter.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = SetupServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("Application Started");

            if (args.Length != 1)
            {
                logger.LogError("Argument number does not match, please specify input file path");
                Console.ReadKey();
                return;
            }

            var service = serviceProvider.GetService<INameSorterService>();
            service.Run(args[0], "sorted-names-list.txt");            

            logger.LogInformation("Application Ended");

            Console.ReadKey();
        }        

        private static ServiceProvider SetupServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddSingleton<INameSorter, LinqSorter>()
                .AddSingleton<IReader, FileReader>()
                .AddSingleton<IWriter, FileWriter>()
                .AddSingleton<INameSorterService, NameSorterService>();
        }
    }
}
