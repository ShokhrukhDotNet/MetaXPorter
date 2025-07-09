//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions;
using Moq;

namespace MetaXPorter.Api.Tests.Unit.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfFileInfoIsNullAndLogItAsync()
        {
            // given
            FileInfo nullFileInfo = null;

            var nullExternalPersonPetFileException = new NullExternalPersonPetFileException();

            var expectedExternalPersonPetValidationException =
                new ExternalPersonPetValidationException(nullExternalPersonPetFileException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync(nullFileInfo);

            ExternalPersonPetValidationException actualExternalPersonPetValidationException =
                await Assert.ThrowsAsync<ExternalPersonPetValidationException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetValidationException.Should()
                .BeEquivalentTo(expectedExternalPersonPetValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetValidationException))), Times.Once);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(It.IsAny<FileInfo>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.sheetBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfFileDoesNotExistAndLogItAsync()
        {
            // given
            FileInfo nonExistentFile = new FileInfo("nonexistent.xlsx");

            var fileNotFoundException = new FileNotFoundExternalException(nonExistentFile.FullName);

            var expectedExternalPersonPetValidationException =
                new ExternalPersonPetValidationException(fileNotFoundException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync(nonExistentFile);

            ExternalPersonPetValidationException actualExternalPersonPetValidationException =
                await Assert.ThrowsAsync<ExternalPersonPetValidationException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetValidationException.Should()
                .BeEquivalentTo(expectedExternalPersonPetValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetValidationException))), Times.Once);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(It.IsAny<FileInfo>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.sheetBrokerMock.VerifyNoOtherCalls();
        }
    }
}
