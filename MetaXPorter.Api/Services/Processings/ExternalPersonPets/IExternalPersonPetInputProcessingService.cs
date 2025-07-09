//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Services.Processings.ExternalPersonPets
{
    public interface IExternalPersonPetInputProcessingService
    {
        FileInfo UploadExternalPersonPetFile(IFormFile externalPersonPetFile);
    }
}
