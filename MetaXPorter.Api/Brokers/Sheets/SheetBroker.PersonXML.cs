//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MetaXPorter.Api.Models.Foundations.Persons;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial class SheetBroker
    {
        public async ValueTask SavePeopleWithPetsToXmlFileAsync(IEnumerable<Person> peopleWithPets, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            xmlSerializer.Serialize(fileStream, peopleWithPets);

            await fileStream.FlushAsync();
        }

        public async ValueTask<MemoryStream> RetrievePeopleWithPetsXmlFileAsync(string filePath)
        {
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            return new MemoryStream(fileBytes);
        }
    }
}
