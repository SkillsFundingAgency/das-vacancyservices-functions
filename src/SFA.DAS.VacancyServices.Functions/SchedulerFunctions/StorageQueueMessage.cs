using System;

namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    [Serializable]
    public class StorageQueueMessage
    {
        public string MessageId { get; set; } = Guid.NewGuid().ToString();
        public string PopReceipt { get; set; } = Guid.NewGuid().ToString();
        public Guid ClientRequestId { get; set; } = Guid.NewGuid();
        public DateTime ExpectedExecutionTime { get; set; } = DateTime.Now;
        public string SchedulerJobId { get; set; }
        public string Message { get; set; }

        public StorageQueueMessage() {} //for serialization 
        public StorageQueueMessage(string jobName)
        {
            Message = jobName;
            SchedulerJobId = jobName;
        }
    }
}