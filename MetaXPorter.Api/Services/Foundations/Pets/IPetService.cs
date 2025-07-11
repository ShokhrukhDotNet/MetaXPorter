//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Pets;

namespace MetaXPorter.Api.Services.Foundations.Pets
{
    public interface IPetService
    {
        ValueTask<Pet> AddPetAsync(Pet pet);
        IQueryable<Pet> RetrieveAllPets();
        ValueTask<Pet> RetrievePetByIdAsync(Guid petId);
        ValueTask<Pet> ModifyPetAsync(Pet pet);
    }
}
