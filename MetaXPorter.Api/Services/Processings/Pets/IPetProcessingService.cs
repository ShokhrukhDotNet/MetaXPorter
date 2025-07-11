//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Pets;

namespace MetaXPorter.Api.Services.Processings.Pets
{
    public interface IPetProcessingService
    {
        ValueTask<Pet> UpsertPetAsync(Pet pet);
        IQueryable<Pet> RetrieveAllPets();
    }
}
