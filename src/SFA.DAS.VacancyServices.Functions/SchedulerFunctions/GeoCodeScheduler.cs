using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class GeoCodeScheduler : SchedulerBase
    {
        public GeoCodeScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.GeoCodeSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(GeoCodeScheduler))]
        public async Task Run(
            [TimerTrigger("%GeoCodeSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(GeoCodeScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}