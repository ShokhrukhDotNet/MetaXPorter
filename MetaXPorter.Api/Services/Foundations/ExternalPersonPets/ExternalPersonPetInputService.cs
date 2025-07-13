//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using MetaXPorter.Api.Brokers.Loggings;
using MetaXPorter.Api.Brokers.Sheets;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetInputService : IExternalPersonPetInputService
    {
        private readonly ISheetBroker sheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExternalPersonPetInputService(
            ISheetBroker sheetBroker,
            ILoggingBroker loggingBroker)
        {
            this.sheetBroker = sheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask UploadExternalPersonPetsFileAsync(IFormFile file) =>
            await TryCatch(async () =>
            {
                ValidateFile(file);

                await this.sheetBroker.UploadExternalPersonPetsFileAsync(file);
            });
    }
}
