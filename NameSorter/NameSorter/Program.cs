using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
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

            var fileName = args[0];
            var inputLines = System.IO.File.ReadAllLines(fileName);

            var sorter = serviceProvider.GetService<INameSorter>();

            var outputLines = sorter.Sort(inputLines);

            foreach (var line in outputLines)
            {
                Console.WriteLine(line);
            }

            System.IO.File.WriteAllLines("sorted-names-list.txt", outputLines);

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
                .AddSingleton<INameSorter, LinqSorter>();
        }
    }
}
