//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorter.Api.Brokers.Queues;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;

namespace MetaXPorter.Api.Services.Foundations.ExternalPersonPets
{
    public class ExternalPersonPetEventService : IExternalPersonPetEventService
    {
        private readonly IQueueBroker queueBroker;

        public ExternalPersonPetEventService(IQueueBroker queueBroker) =>
            this.queueBroker = queueBroker;

        public ValueTask AddExternalPersonPets(List<ExternalPerson> externalPersonPets) =>
            this.queueBroker.AddExternalPersonPets(externalPersonPets);

        public ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets() =>
            this.queueBroker.ReadExternalPersonPets();
    }
}
