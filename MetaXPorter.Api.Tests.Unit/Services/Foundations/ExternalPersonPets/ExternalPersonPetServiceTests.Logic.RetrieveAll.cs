//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using Moq;

namespace MetaXPorter.Api.Tests.Unit.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllExternalPersonPets()
        {
            // given
            FileInfo inputFile = new FileInfo(Path.GetTempFileName());
            List<ExternalPerson> randomExternalPersonPets = CreateRandomExternalPersonPets();
            List<ExternalPerson> storageExternalPersonPets = randomExternalPersonPets;
            List<ExternalPerson> expectedExternalPersonPets = storageExternalPersonPets.DeepClone();

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync(inputFile))
                    .ReturnsAsync(storageExternalPersonPets);

            // when
            List<ExternalPerson> actualExternalPersonPets =
                await this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync(inputFile);

            // then
            actualExternalPersonPets.Should().BeEquivalentTo(expectedExternalPersonPets);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(inputFile),
                    Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
