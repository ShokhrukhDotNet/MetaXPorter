//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.Pets.Exceptions
{
    public class AlreadyExistPetException : Xeption
    {
        public AlreadyExistPetException(Exception innerException)
            : base(message: "Pet already exists", innerException)
        { }
    }
}
