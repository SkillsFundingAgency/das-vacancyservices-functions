# Digital Apprenticeships Service
## Vacancy Services Functions
|               |               |
| ------------- | ------------- |
|![crest](https://assets.publishing.service.gov.uk/government/assets/crests/org_crest_27px-916806dcf065e7273830577de490d5c7c42f36ddec83e907efe62086785f24fb.png)|Vacancy Services Functions|
| Build | [![Build Status](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_apis/build/status/das-vacancyservices-functions?branchName=master)](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build/latest?definitionId=1901&branchName=master) |

| Environment | URL |
|-- | -- |
| AT | https://das-at-vacwkr-fa.azurewebsites.net/ |
| TEST | https://das-test-vacwkr-fa.azurewebsites.net/ |
| TEST2 | https://das-test2-vacwkr-fa.azurewebsites.net/ |
| PP | https://das-pp-vacwkr-fa.azurewebsites.net/ |
| PROD | https://das-prd-vacwkr-fa.azurewebsites.net/ |

## Developer setup
### Requirements
Azure storage account or Azure storage emulator (set as default in the [settings file](src/SFA.DAS.VacancyServices.Functions/local.settings.json#L4))

### SFA.DAS.VacancyServices.Functions
#### SchedulerFunctions
These functions run on scheduled basis. The default schedule is defined in the [settings file](src/SFA.DAS.VacancyServices.Functions/local.settings.json#L11). These functions primarily drop a message on Azure storage queue which in turn triggers respective process in FAA and RAA V1 worker roles. 

## See also
* [Manually run a non HTTP-triggered function](https://docs.microsoft.com/en-us/azure/azure-functions/functions-manually-run-non-http)
