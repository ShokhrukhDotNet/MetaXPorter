//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using MetaXPorter.Api.Brokers.Sheets;
using MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public class ExternalPersonPetInputService : IExternalPersonPetInputService
    {
        private readonly ISheetBroker sheetBroker;

        public ExternalPersonPetInputService(ISheetBroker sheetBroker) =>
            this.sheetBroker = sheetBroker;

        public FileInfo UploadExternalPersonPetFile(IFormFile externalPersonPetFile)
        {
            if (externalPersonPetFile is null)
            {
                throw new NullExternalPersonPetFileException();
            }

            return this.sheetBroker.UploadFile(externalPersonPetFile);
        }
    }
}
