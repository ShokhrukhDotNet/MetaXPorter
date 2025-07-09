//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions
{
    public class NullExternalPersonPetFileException : Xeption
    {
        public NullExternalPersonPetFileException()
            : base(message: "Externalpersonpet file is null")
        { }
    }
}
