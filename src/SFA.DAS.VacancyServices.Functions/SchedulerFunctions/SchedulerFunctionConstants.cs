namespace SFA.DAS.VacancyServices.Functions.SchedulerFunctions
{
    public static class SchedulerFunctionConstants
    {
        public const string RecruitV1StorageConnectionStringKey = "RecruitV1StorageConnectionString";

        public static class QueueNames
        {
            public const string DailyDigestSchedulerQueueName = "dailydigestscheduler";
            public const string DailyMetricsSchedulerQueueName = "dailymetricsscheduler";
            public const string GeoCodeSchedulerQueueName = "geocodescheduler";
            public const string HouseKeepingSchedulerQueueName = "housekeepingscheduler";
            public const string MonitorSchedulerQueueName = "monitorscheduler";
            public const string ReferenceDataSchedulerQueueName = "referencedatascheduler";
            public const string SavedSearchSchedulerQueueName = "savedsearchscheduler";
            public const string VacancyIndexSchedulerQueueName = "vacancyindexscheduler";
            public const string VacancyStatusSchedulerQueueName = "vacancystatusscheduler";
        }
    }
}