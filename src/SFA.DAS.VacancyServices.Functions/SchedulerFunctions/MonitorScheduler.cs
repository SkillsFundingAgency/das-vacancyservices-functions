using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class MonitorScheduler : SchedulerBase
    {
        public MonitorScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.MonitorSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(MonitorScheduler))]
        public async Task Run(
            [TimerTrigger("%MonitorSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(MonitorScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}