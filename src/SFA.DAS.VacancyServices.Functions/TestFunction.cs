using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions
{
    public class TestFunction
    {
        const string QueueName = "functestqueue";
        private readonly StorageQueueService _service;
        public TestFunction(StorageQueueService service)
        {
            _service = service;
        }
        [FunctionName("TestFunction")]
        public async Task Run(
            [TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, 
            //[Queue("FuncTestQueue"), StorageAccount("RecruitV1StorageConnectionString")] ICollector<string> msg,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //msg.Add(AzureQueueStorageMessageHelper.GetSerialisedQueueMessage("FuncTestQueue").AsString);
            await _service.SendMessageAsync(QueueName);
        }
    }
}
