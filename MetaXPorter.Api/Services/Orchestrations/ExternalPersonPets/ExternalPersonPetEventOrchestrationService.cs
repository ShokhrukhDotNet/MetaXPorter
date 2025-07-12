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

        public ExternalPersonPetEventOrchestrationService(
            IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService) =>
                this.externalPersonPetEventProcessingService = externalPersonPetEventProcessingService;

        public ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets() =>
            this.externalPersonPetEventProcessingService.RetrieveExternalPersonPets();
    }
}
