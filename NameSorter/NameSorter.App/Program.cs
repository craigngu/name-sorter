using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NameSorter.App.Config;
using NameSorter.App.Helpers;
using NameSorter.App.Implementations;
using NameSorter.App.Interfaces;
using NameSorter.App.Models;
using System;
using System.Collections.Generic;
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
                // End application when input file is not provided
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
                .AddSingleton<IComparer<Person>, PersonNameComparer>()
                .AddSingleton<ISorter<Person>, BubbleSorter<Person>>()
                .AddSingleton<INameSorter, PersonNameSorter>()
                .AddSingleton<IReader, FileReader>()
                .AddSingleton<FileWriter>()
                .AddSingleton<ConsoleWriter>()
                .AddSingleton<IWriter>(sp => new CompositeWriter(new List<IWriter> {
                    sp.GetService<FileWriter>(),
                    sp.GetService<ConsoleWriter>()
                }))
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
            // output path is stored in config for now
            return new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .Build();
        }
    }
}
