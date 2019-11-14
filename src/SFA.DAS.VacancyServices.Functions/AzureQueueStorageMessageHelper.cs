using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Storage.Queue;

namespace SFA.DAS.VacancyServices.Functions
{
    public class AzureQueueStorageMessageHelper
    {
        public static CloudQueueMessage GetSerialisedQueueMessage(string jobName)
        {
            var queueMessage = new StorageQueueMessage(jobName);
            var serializer = new XmlSerializer(typeof(StorageQueueMessage));
            string message;

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, queueMessage);
                ms.Position = 0;
                var sr = new StreamReader(ms);
                message = sr.ReadToEnd();
            }

            var cloudMessage = new CloudQueueMessage(message);

            return cloudMessage;
        }
    }

    [Serializable]
    public class StorageQueueMessage
    {
        public string MessageId { get; set; } = Guid.NewGuid().ToString();
        public string PopReceipt { get; set; } = Guid.NewGuid().ToString();
        public Guid ClientRequestId { get; set; } = Guid.NewGuid();
        public DateTime ExpectedExecutionTime { get; set; } = DateTime.Now;
        public string SchedulerJobId { get; set; }
        public string Message { get; set; }

        public StorageQueueMessage() {} //for serialisation 
        public StorageQueueMessage(string jobName)
        {
            Message = jobName;
            SchedulerJobId = jobName;
        }
    }
}