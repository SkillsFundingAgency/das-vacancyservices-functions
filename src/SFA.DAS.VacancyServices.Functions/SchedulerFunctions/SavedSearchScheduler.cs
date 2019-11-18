using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class SavedSearchScheduler : SchedulerBase
    {
        public SavedSearchScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.SavedSearchSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(SavedSearchScheduler))]
        public async Task Run(
            [TimerTrigger("%SavedSearchSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(SavedSearchScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}