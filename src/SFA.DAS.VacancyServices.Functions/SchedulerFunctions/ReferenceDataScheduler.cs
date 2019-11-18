using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class ReferenceDataScheduler : SchedulerBase
    {
        public ReferenceDataScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.ReferenceDataSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(ReferenceDataScheduler))]
        public async Task Run(
            [TimerTrigger("%ReferenceDataSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(ReferenceDataScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}