using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public class VacancyIndexScheduler : SchedulerBase
    {
        public override string QueueName => SchedulerFunctionConstants.QueueNames.VacancyIndexSchedulerQueueName;
        private readonly StorageQueueService _service;
        public VacancyIndexScheduler(StorageQueueService service)
        {
            _service = service;
        }

        [FunctionName("vacancy-index-scheduler")]
        public async Task Run(
            [TimerTrigger("%VacancyIndexSchedule%")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"{nameof(VacancyIndexScheduler)} triggered at {DateTime.Now}");
            var message = GetSchedulerMessage();
            await _service.AddMessageAsync(
                SchedulerFunctionConstants.RecruitV1StorageConnectionStringKey, QueueName, message);
        }
    }
}