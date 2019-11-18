using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SFA.DAS.VacancyServices.Functions.Infrastructure;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public abstract class SchedulerBase
    {
        private readonly StorageQueueService _service;
        public string QueueName { get; }
        public SchedulerBase(string queueName, StorageQueueService service)
        {
            QueueName = queueName;
            _service = service;
        }
        public Task AddMessageToQueueAsync()
        {
            var message = GetSchedulerMessage();
            return _service.AddMessageAsync(
                SchedulerFunctionConstants.RecruitV1StorageConnectionStringKey, QueueName, message);

        }
        private string GetSchedulerMessage()
        {
            var queueMessage = new StorageQueueMessage(QueueName);
            var serializer = new XmlSerializer(typeof(StorageQueueMessage));
            string message;

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, queueMessage);
                ms.Position = 0;
                var sr = new StreamReader(ms);
                message = sr.ReadToEnd();
            }
            return message;
        }
    }
}