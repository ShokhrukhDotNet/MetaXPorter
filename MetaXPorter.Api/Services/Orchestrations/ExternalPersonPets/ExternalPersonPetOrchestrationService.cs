//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using MetaXPorter.Api.Services.Processings.ExternalPersonPets;

namespace MetaXPorter.Api.Services.Orchestrations.ExternalPersonPets
{
    public class ExternalPersonPetOrchestrationService : IExternalPersonPetOrchestrationService
    {
        private readonly IExternalPersonPetProcessingService externalPersonPetProcessingService;
        private readonly IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService;

        public ExternalPersonPetOrchestrationService(
            IExternalPersonPetProcessingService externalPersonPetProcessingService,
            IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService)
        {
            this.externalPersonPetProcessingService = externalPersonPetProcessingService;
            this.externalPersonPetEventProcessingService = externalPersonPetEventProcessingService;
        }

        public async ValueTask RetrieveAndAddFormattedExternalPersonPetsAsync(FileInfo fileInfo)
        {
            List<ExternalPerson> formattedExternalPersonPets =
                await this.externalPersonPetProcessingService
                    .RetrieveFormattedExternalPersonPetsAsync(fileInfo);

            await this.externalPersonPetEventProcessingService
                .AddExternalPersonPets(formattedExternalPersonPets);
        }
    }
}
