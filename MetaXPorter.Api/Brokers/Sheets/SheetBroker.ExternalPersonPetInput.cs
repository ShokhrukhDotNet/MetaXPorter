//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial class SheetBroker
    {
        public FileInfo UploadFile(IFormFile file) =>
            GetFileInfo(file);
    }
}
