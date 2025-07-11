//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.Persons.Exceptions
{
    public class AlreadyExistPersonException : Xeption
    {
        public AlreadyExistPersonException(Exception innerException)
            : base(message: "Person already exists", innerException)
        { }
    }
}
