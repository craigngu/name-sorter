using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
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

            if(args.Length != 1)
            {
                logger.LogError("Argument number does not match, please specify input file path");
                Console.ReadKey();
                return;
            }

            var fileName = args[0];
            var inputLines = System.IO.File.ReadAllLines(fileName);

            var outputLines = inputLines.OrderBy(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last())
                .ThenBy(l => l)
                .ToList();

            foreach(var line in outputLines)
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
            services.AddLogging(configure => configure.AddConsole());
        }
    }
}
