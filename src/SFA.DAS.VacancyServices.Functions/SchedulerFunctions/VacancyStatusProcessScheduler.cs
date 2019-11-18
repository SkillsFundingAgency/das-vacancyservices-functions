using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class VacancyStatusProcessScheduler : SchedulerBase
    {
        public VacancyStatusProcessScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.VacancyStatusSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(VacancyStatusProcessScheduler))]
        public async Task Run(
            [TimerTrigger("%VacancyStatusProcessorSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(VacancyStatusProcessScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}