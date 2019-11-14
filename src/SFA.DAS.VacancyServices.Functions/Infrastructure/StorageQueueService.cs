using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace SFA.DAS.VacancyServices.Functions.Infrastructure
{
    public class StorageQueueService
    {
        const string RecruitV1StorageConnectionStringKey = "RecruitV1StorageConnectionString"; 
        private readonly CloudQueueClient _queueClient;
        public StorageQueueService(IConfiguration config)
        {
            var recruitV1StorageConnectionString = config.GetConnectionStringOrSetting(RecruitV1StorageConnectionStringKey);
            var storageAccount = CloudStorageAccount.Parse(recruitV1StorageConnectionString);
	        _queueClient = storageAccount.CreateCloudQueueClient();
        }

        public async Task SendMessageAsync(string queueName)
        {
            var queue = _queueClient.GetQueueReference(queueName);
            var qe = await queue.ExistsAsync();
            var msg = AzureQueueStorageMessageHelper.GetSerialisedQueueMessage(queueName);
            await queue.AddMessageAsync(msg);
        }
    }
}