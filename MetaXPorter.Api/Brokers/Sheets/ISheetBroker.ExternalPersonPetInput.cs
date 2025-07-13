//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial interface ISheetBroker
    {
        ValueTask UploadExternalPersonPetsFileAsync(IFormFile file);
    }
}
