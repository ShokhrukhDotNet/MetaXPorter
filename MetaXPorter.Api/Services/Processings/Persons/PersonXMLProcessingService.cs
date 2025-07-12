//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Persons;
using MetaXPorter.Api.Services.Foundations.Persons;

namespace MetaXPorter.Api.Services.Processings.Persons
{
    public class PersonXMLProcessingService : IPersonXMLProcessingService
    {
        private readonly IPersonXMLService personXMLService;

        public PersonXMLProcessingService(IPersonXMLService personXMLService) =>
            this.personXMLService = personXMLService;

        public ValueTask ExportPersonPetsToXml(IEnumerable<Person> persons, string filePath) =>
            this.personXMLService.ExportPersonPetsToXml(persons, filePath);

        public ValueTask<Stream> RetrievePersonPetsXml(string filePath) =>
            this.personXMLService.RetrievePersonPetsXml(filePath);
    }
}
