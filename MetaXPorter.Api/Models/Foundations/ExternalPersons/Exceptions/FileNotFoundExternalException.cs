//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions
{
    public class FileNotFoundExternalException : Xeption
    {
        public FileNotFoundExternalException(string filePath)
            : base(message: $"Couldn't find external file at path: {filePath}")
        { }
    }
}
