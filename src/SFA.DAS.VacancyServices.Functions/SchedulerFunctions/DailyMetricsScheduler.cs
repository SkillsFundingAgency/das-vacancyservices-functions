using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class DailyMetricsScheduler : SchedulerBase
    {
        public DailyMetricsScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.DailyMetricsSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(DailyMetricsScheduler))]
        public async Task Run(
            [TimerTrigger("%DailyMetricsSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(DailyMetricsScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}