//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;
using MetaXPorter.Api.Services.Foundations.Persons;

namespace MetaXPorter.Api.Services.Processings.Persons
{
    public class PersonProcessingService : IPersonProcessingService
    {
        private readonly IPersonService personService;

        public PersonProcessingService(IPersonService personService) =>
            this.personService = personService;

        public async ValueTask<Person> UpsertPersonAsync(Person person)
        {
            Person maybePerson = RetrievePerson(person);

            return maybePerson switch
            {
                null => await this.personService.AddPersonAsync(person),
                _ => await this.personService.ModifyPersonAsync(person)
            };
        }

        private Person RetrievePerson(Person person)
        {
            IQueryable<Person> retrievedPersons =
                this.personService.RetrieveAllPeople();

            return retrievedPersons.FirstOrDefault(storagePerson =>
                storagePerson.Id == person.Id);
        }

        public IQueryable<Person> RetrieveAllPeople() =>
            personService.RetrieveAllPeople();

        public IQueryable<Person> RetrieveAllPeopleWithPets() =>
            personService.RetrieveAllPeopleWithPets();
    }
}
