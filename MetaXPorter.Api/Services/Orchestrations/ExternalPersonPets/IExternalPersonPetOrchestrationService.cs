//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;

namespace MetaXPorter.Api.Services.Orchestrations.ExternalPersonPets
{
    public interface IExternalPersonPetOrchestrationService
    {
        ValueTask RetrieveAndAddFormattedExternalPersonPetsAsync(FileInfo fileInfo);
    }
}
