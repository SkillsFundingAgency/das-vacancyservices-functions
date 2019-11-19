using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class HouseKeepingScheduler : SchedulerBase
    {
        public HouseKeepingScheduler(StorageQueueService service)
        : base(SchedulerFunctionConstants.QueueNames.HouseKeepingSchedulerQueueName, service)
        {
        }

        [FunctionName(nameof(HouseKeepingScheduler))]
        public async Task Run(
            [TimerTrigger("%HouseKeepingSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(HouseKeepingScheduler)} triggered at {DateTime.Now}");
            await AddMessageToQueueAsync();
        }
    }
}