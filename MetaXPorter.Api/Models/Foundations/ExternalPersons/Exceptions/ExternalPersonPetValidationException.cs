//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions
{
    public class ExternalPersonPetValidationException : Xeption
    {
        public ExternalPersonPetValidationException(Xeption innerException)
            : base(message: "ExternalPersonPet validation error occured, fix the errors and try again",
                  innerException)
        { }
    }
}
