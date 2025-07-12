//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Services.Foundations.Persons
{
    public interface IPersonXMLService
    {
        ValueTask ExportPersonPetsToXml(IEnumerable<Person> persons, string filePath);
        ValueTask<Stream> RetrievePersonPetsXml(string filePath);
    }
}
