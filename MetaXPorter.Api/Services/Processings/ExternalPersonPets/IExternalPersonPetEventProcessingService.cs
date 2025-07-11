//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;

namespace MetaXPorter.Api.Services.Processings.ExternalPersonPets
{
    public interface IExternalPersonPetEventProcessingService
    {
        ValueTask AddExternalPersonPets(List<ExternalPerson> externalPersonPets);
        ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets();
    }
}
