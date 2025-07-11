//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using MetaXPorter.Api.Models.Orchestrations.PersonPets;

namespace MetaXPorter.Api.Services.Orchestrations.PersonPets
{
    public interface IPersonPetOrchestrationService
    {
        ValueTask<PersonPet> ProcessPersonWithPetsAsync(PersonPet personPet);
    }
}
