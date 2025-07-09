//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public interface IExternalPersonPetInputService
    {
        FileInfo UploadExternalPersonPetFile(IFormFile externalPersonPetFile);
    }
}
