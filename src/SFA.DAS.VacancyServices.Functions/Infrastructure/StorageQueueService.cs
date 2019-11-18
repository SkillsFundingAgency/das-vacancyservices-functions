using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace SFA.DAS.VacancyServices.Functions.Infrastructure
{
    public class StorageQueueService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<StorageQueueService> _logger;
        public StorageQueueService(IConfiguration config, ILogger<StorageQueueService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task AddMessageAsync(string storageConnectionStringKey, string queueName, string message)
        {
            _logger.LogInformation($"Queuing up message on {queueName}");
            var connectionString = _config.GetConnectionStringOrSetting(storageConnectionStringKey);
            var storageAccount = CloudStorageAccount.Parse(connectionString);
	        var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);
            var qe = await queue.ExistsAsync();
            var cloudMessage = new CloudQueueMessage(message);
            await queue.AddMessageAsync(cloudMessage);
        }
    }
}