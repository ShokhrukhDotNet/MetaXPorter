//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
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
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfIOExceptionOccursAndLogItAsync()
        {
            // given
            string filePath = Path.Combine(Path.GetTempPath(), "dummy.xlsx");
            File.WriteAllText(filePath, "fake content");
            FileInfo someFile = new FileInfo(filePath);

            var ioException = new IOException();

            var failedExternalPersonPetDependencyException =
                new FailedExternalPersonPetDependencyException(ioException);

            var expectedExternalPersonPetDependencyException =
                new ExternalPersonPetDependencyException(failedExternalPersonPetDependencyException);

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync(someFile))
                    .ThrowsAsync(ioException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync(someFile);

            ExternalPersonPetDependencyException actualExternalPersonPetDependencyException =
                await Assert.ThrowsAsync<ExternalPersonPetDependencyException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetDependencyException.Should()
                .BeEquivalentTo(expectedExternalPersonPetDependencyException);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(someFile), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetDependencyException))), Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

            File.Delete(filePath);
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccursAndLogItAsync()
        {
            // given
            string filePath = Path.Combine(Path.GetTempPath(), "dummy.xlsx");
            File.WriteAllText(filePath, "fake content");
            FileInfo someFile = new FileInfo(filePath);

            string exceptionMessage = GetRandomString();
            var serviceException = new Exception(exceptionMessage);

            var failedExternalPersonPetServiceException =
                new FailedExternalPersonPetServiceException(serviceException);

            var expectedExternalPersonPetServiceException =
                new ExternalPersonPetServiceException(failedExternalPersonPetServiceException);

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync(someFile))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync(someFile);

            ExternalPersonPetServiceException actualExternalPersonPetServiceException =
                await Assert.ThrowsAsync<ExternalPersonPetServiceException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetServiceException.Should()
                .BeEquivalentTo(expectedExternalPersonPetServiceException);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(someFile), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetServiceException))), Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

            File.Delete(filePath);
        }
    }
}
