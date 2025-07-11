//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Orchestrations.PersonPets;

namespace MetaXPorter.Api.Services.Coordinations
{
    public interface IPersonPetEventCoordinationService
    {
        ValueTask<List<PersonPet>> CoordinateExternalPersonPetsAsync();
    }
}
