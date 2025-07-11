//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Services.Processings.Persons
{
    public interface IPersonProcessingService
    {
        ValueTask<Person> UpsertPersonAsync(Person person);
        IQueryable<Person> RetrieveAllPeople();
        IQueryable<Person> RetrieveAllPeopleWithPets();
    }
}
