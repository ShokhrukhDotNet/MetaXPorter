//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;

namespace MetaXPorter.Api.Services.Processings.ExternalPersonPets
{
    public interface IExternalPersonPetProcessingService
    {
        ValueTask<List<ExternalPerson>> RetrieveFormattedExternalPersonPetsAsync();
    }
}
