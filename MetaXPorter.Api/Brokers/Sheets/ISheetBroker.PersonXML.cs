//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial interface ISheetBroker
    {
        ValueTask SavePeopleWithPetsToXmlFile(IEnumerable<Person> peopleWithPets, string filePath);

        ValueTask<MemoryStream> RetrievePeopleWithPetsXmlFile(string filePath);
    }
}
