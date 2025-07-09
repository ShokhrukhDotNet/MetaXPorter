//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MetaXPorter.Api.Brokers.Loggings;
using MetaXPorter.Api.Brokers.Sheets;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using MetaXPorter.Api.Services.Foundations.ExternalPersonPets;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace MetaXPorter.Api.Tests.Unit.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetServiceTests
    {
        private readonly Mock<ISheetBroker> sheetBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IExternalPersonPetService externalPersonPetService;

        public ExternalPersonPetServiceTests()
        {
            this.sheetBrokerMock = new Mock<ISheetBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.externalPersonPetService = new ExternalPersonPetService(
                sheetBroker: this.sheetBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static List<ExternalPerson> CreateRandomExternalPersonPets() =>
            CreateExternalPersonPetFiller().Create(count: GetRandomNumber()).ToList();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static Filler<ExternalPerson> CreateExternalPersonPetFiller()
        {
            var filler = new Filler<ExternalPerson>();
            return filler;
        }
    }
}
