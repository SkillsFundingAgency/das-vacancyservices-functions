using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class DailyDigestScheduler : SchedulerBase
    {
        public DailyDigestScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.DailyDigestSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(DailyDigestScheduler))]
        public async Task Run(
            [TimerTrigger("%DailyDigestSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(DailyDigestScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}