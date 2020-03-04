using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class LegacyDatabaseHousekeepingScheduler : SchedulerBase
    {
        public LegacyDatabaseHousekeepingScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.LegacyDatabaseHousekeepingQueueName, service)
        {
        }

        [FunctionName(nameof(LegacyDatabaseHousekeepingScheduler))]
        public async Task Run(
            [TimerTrigger("%LegacyDatabaseHousekeepingSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(LegacyDatabaseHousekeepingScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}