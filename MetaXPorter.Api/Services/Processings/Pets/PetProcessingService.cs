//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.Pets;
using MetaXPorter.Api.Services.Foundations.Pets;

namespace MetaXPorter.Api.Services.Processings.Pets
{
    public class PetProcessingService : IPetProcessingService
    {
        private readonly IPetService petService;

        public PetProcessingService(IPetService petService) =>
            this.petService = petService;

        public async ValueTask<Pet> UpsertPetAsync(Pet pet)
        {
            Pet maybePet =
                await this.petService.RetrievePetByIdAsync(pet.Id);

            return maybePet switch
            {
                null => await this.petService.AddPetAsync(pet),
                _ => await this.petService.ModifyPetAsync(pet)
            };
        }

        public IQueryable<Pet> RetrieveAllPets() =>
            this.petService.RetrieveAllPets();
    }
}
