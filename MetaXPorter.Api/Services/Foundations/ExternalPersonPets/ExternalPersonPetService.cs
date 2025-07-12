//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Brokers.Loggings;
using MetaXPorter.Api.Brokers.Sheets;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetService : IExternalPersonPetService
    {
        private readonly ISheetBroker sheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExternalPersonPetService(
            ISheetBroker sheetBroker,
            ILoggingBroker loggingBroker)
        {
            this.sheetBroker = sheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<ExternalPerson>> RetrieveAllExternalPersonPetsAsync() =>
        TryCatch(async () =>
            await this.sheetBroker.ReadAllExternalPersonPetsAsync());
    }
}