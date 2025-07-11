//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Pets;

namespace MetaXPorter.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Pet> InsertPetAsync(Pet pet);
        IQueryable<Pet> SelectAllPets();
        ValueTask<Pet> SelectPetByIdAsync(Guid petId);
        ValueTask<Pet> UpdatePetAsync(Pet pet);
    }
}
