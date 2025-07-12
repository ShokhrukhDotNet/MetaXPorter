//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Brokers.Sheets;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Services.Foundations.Persons
{
    public class PersonXMLService : IPersonXMLService
    {
        private readonly ISheetBroker sheetBroker;

        public PersonXMLService(ISheetBroker sheetBroker) =>
            this.sheetBroker = sheetBroker;

        public async ValueTask ExportPersonPetsToXml(
            IEnumerable<Person> persons, string filePath) =>
                await this.sheetBroker.SavePeopleWithPetsToXmlFile(persons, filePath);

        public async ValueTask<Stream> RetrievePersonPetsXml(string filePath) =>
            await this.sheetBroker.RetrievePeopleWithPetsXmlFile(filePath);
    }
}
