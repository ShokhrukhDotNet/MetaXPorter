//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial interface ISheetBroker
    {
        void SavePeopleWithPetsToXmlFile(IEnumerable<Person> peopleWithPets, string filePath);

        MemoryStream RetrievePeopleWithPetsXmlFile(string filePath);
    }
}
