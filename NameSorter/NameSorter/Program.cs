using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NameSorter.App.Config;
using System;
using System.IO;
using System.Linq;

namespace NameSorter.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Argument number does not match, please specify input file path");
                Console.ReadKey();
                return;
            }

            var inputPath = args.Single();
            var serviceProvider = SetupServiceProvider(inputPath);

            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("Application Started");

            var service = serviceProvider.GetService<INameSorterService>();
            service.Run();

            logger.LogInformation("Application Ended");

            Console.ReadKey();
        }

        private static ServiceProvider SetupServiceProvider(string inputPath)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, inputPath);

            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services, string inputPath)
        {
            IConfigurationRoot config = GetConfig();

            services.AddLogging(configure => configure.AddConsole())
                .AddSingleton(GetOutputPath(config))
                .AddSingleton(new InputPath { Value = inputPath })
                .AddSingleton<INameSorter, LinqSorter>()
                .AddSingleton<IReader, FileReader>()
                .AddSingleton<IWriter, FileWriter>()
                .AddSingleton<INameSorterService, NameSorterService>();
        }

        private static OutputPath GetOutputPath(IConfigurationRoot config)
        {
            return new OutputPath
            {
                Value = config.GetValue<string>("outputPath")
            };
        }

        private static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .Build();
        }
    }
}
