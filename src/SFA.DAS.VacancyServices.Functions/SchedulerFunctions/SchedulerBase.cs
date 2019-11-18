using System.IO;
using System.Xml.Serialization;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public abstract class SchedulerBase
    {
        public abstract string QueueName { get; }
        public string GetSchedulerMessage()
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