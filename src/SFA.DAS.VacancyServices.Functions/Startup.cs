using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

[assembly: FunctionsStartup(typeof(Startup))]

namespace SFA.DAS.VacancyServices.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var sp = builder.Services.BuildServiceProvider();

            var configuration = sp.GetService<IConfiguration>();

            var nLogConfiguration = new NLogConfiguration();

            builder.Services.AddLogging((options) =>
            {
                options.SetMinimumLevel(LogLevel.Trace);
                options.SetMinimumLevel(LogLevel.Trace);
                options.AddNLog(new NLogProviderOptions
                {
                    CaptureMessageTemplates = true,
                    CaptureMessageProperties = true
                });

                nLogConfiguration.ConfigureNLog(configuration);
            })
            .AddTransient<StorageQueueService>();

            var config = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
