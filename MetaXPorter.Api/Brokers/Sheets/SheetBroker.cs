//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial class SheetBroker : ISheetBroker, IDisposable
    {
        public void Dispose() { }

        private FileInfo GetFileInfo(IFormFile file)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), file.FileName);

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return new FileInfo(tempPath);
        }
    }
}
