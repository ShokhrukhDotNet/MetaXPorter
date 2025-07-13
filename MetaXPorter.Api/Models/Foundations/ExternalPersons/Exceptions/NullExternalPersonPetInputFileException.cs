//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions
{
    public class NullExternalPersonPetInputFileException : Xeption
    {
        public NullExternalPersonPetInputFileException()
            : base(message: "Input file is null. Please upload a valid file.")
        { }
    }
}
