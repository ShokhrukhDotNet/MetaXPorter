//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using MetaXPorter.Api.Models.Foundations.Persons;
using MetaXPorter.Api.Models.Foundations.Pets;

namespace MetaXPorter.Api.Models.Orchestrations.PersonPets
{
    public class PersonPet
    {
        public Person Person { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
