//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Person> InsertPersonAsync(Person person);
        IQueryable<Person> SelectAllPeople();
        IQueryable<Person> SelectAllPeopleWithPets();
        ValueTask<Person> SelectPersonByIdAsync(Guid personId);
        ValueTask<Person> UpdatePersonAsync(Person person);
    }
}
