//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using MetaXPorter.Api.Services.Processings.ExternalPersonPets;

namespace MetaXPorter.Api.Services.Orchestrations.ExternalPersonPets
{
    public class ExternalPersonPetEventOrchestrationService : IExternalPersonPetEventOrchestrationService
    {
        private readonly IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService;
        private readonly IExternalPersonPetOrchestrationService externalPersonPetOrchestrationService;

        public ExternalPersonPetEventOrchestrationService(
            IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService,
            IExternalPersonPetOrchestrationService externalPersonPetOrchestrationService)
        {
            this.externalPersonPetEventProcessingService = externalPersonPetEventProcessingService;
            this.externalPersonPetOrchestrationService = externalPersonPetOrchestrationService;
        }

        public async ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets()
        {
            await this.externalPersonPetOrchestrationService.RetrieveAndAddFormattedExternalPersonPetsAsync();

            return await this.externalPersonPetEventProcessingService.RetrieveExternalPersonPets();
        }
    }
}
