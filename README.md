# Vacancy Services Functions
## Developer setup
### Requirements
Azure storage account or Azure storage emulator (set as default in the [settings file](src/SFA.DAS.VacancyServices.Functions/local.settings.json))

### SFA.DAS.VacancyServices.Functions
#### SchedulerFunctions
These functions run on scheduled basis. The default schedule is defined in the [settings file](src/SFA.DAS.VacancyServices.Functions/local.settings.json). These functions primarily drop a message on Azure storage queue which is turn triggers a process. 
