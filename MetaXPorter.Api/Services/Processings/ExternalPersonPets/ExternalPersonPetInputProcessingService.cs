//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
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

        public FileInfo UploadExternalPersonPetFile(IFormFile externalPersonPetFile) =>
            this.externalPersonPetInputService.UploadExternalPersonPetFile(externalPersonPetFile);
    }
}
