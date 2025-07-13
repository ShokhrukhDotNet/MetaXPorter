//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using MetaXPorter.Api.Services.Foundations.ExternalPersonPets;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Services.Processings.ExternalPersonPets
{
    public class ExternalPersonPetInputProcessingService : IExternalPersonPetInputProcessingService
    {
        private readonly IExternalPersonPetInputService externalPersonPetInputService;

        public ExternalPersonPetInputProcessingService(
            IExternalPersonPetInputService externalPersonPetInputService) =>
                this.externalPersonPetInputService = externalPersonPetInputService;

        public ValueTask UploadExternalPersonPetsFileAsync(IFormFile file) =>
            this.externalPersonPetInputService.UploadExternalPersonPetsFileAsync(file);
    }
}
