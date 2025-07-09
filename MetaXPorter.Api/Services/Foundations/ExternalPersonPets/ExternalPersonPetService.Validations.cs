//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetService
    {
        private static void ValidateFileInfoIsNotNull(FileInfo fileInfo)
        {
            if (fileInfo is null)
            {
                throw new NullExternalPersonPetFileException();
            }
        }

        private static void ValidateFileExists(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundExternalException(fileInfo.FullName);
            }
        }
    }
}
