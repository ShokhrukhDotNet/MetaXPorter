//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorter.Api.Models.Foundations.Pets.Exceptions
{
    public class NotFoundPetException : Xeption
    {
        public NotFoundPetException(Guid petId)
            : base(message: $"Couldn't find pet with id {petId}")
        { }
    }
}
