using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class VacancyIndexScheduler : SchedulerBase
    {
        public VacancyIndexScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.VacancyIndexSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(VacancyIndexScheduler))]
        public async Task Run(
            [TimerTrigger("%VacancyIndexSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(VacancyIndexScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}