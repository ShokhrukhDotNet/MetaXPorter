//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons.Exceptions;
using MetaXPorter.Api.Models.Foundations.Persons.Exceptions;
using MetaXPorter.Api.Models.Orchestrations.PersonPets;
using MetaXPorter.Api.Services.Coordinations;
using MetaXPorter.Api.Services.Orchestrations.Persons;
using MetaXPorter.Api.Services.Processings.ExternalPersonPets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MetaXPorter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : RESTFulController
    {
        private readonly IExternalPersonPetInputProcessingService externalPersonPetInputProcessingService;
        private readonly IPersonPetEventCoordinationService personPetEventCoordinationService;
        private readonly IPersonOrchestrationService personOrchestrationService;

        public PeopleController(
            IExternalPersonPetInputProcessingService externalPersonPetInputProcessingService,
            IPersonPetEventCoordinationService personPetEventCoordinationService,
            IPersonOrchestrationService personOrchestrationService)
        {
            this.externalPersonPetInputProcessingService = externalPersonPetInputProcessingService;
            this.personPetEventCoordinationService = personPetEventCoordinationService;
            this.personOrchestrationService = personOrchestrationService;
        }

        [HttpPost("upload-and-store")]
        public async ValueTask<ActionResult<List<PersonPet>>> UploadAndStorePeople(IFormFile file)
        {
            try
            {
                await this.externalPersonPetInputProcessingService.UploadExternalPersonPetsFileAsync(file);

                List<PersonPet> storedPeople =
                    await this.personPetEventCoordinationService.CoordinateExternalPersonPetsAsync();

                return Ok(storedPeople);
            }
            catch (NullExternalPersonPetInputFileException nullExternalPersonPetInputFileException)
            {
                return BadRequest(new { Error = nullExternalPersonPetInputFileException.Message });
            }
            catch (EmptyExternalPersonPetInputFileException emptyExternalPersonPetInputFileException)
            {
                return BadRequest(new { Error = emptyExternalPersonPetInputFileException.Message });
            }
            catch (InvalidExternalPersonPetInputFileTypeException InputFileTypeException)
            {
                return BadRequest(new { Error = InputFileTypeException.Message });
            }
            catch (ExternalPersonPetDependencyException externalPersonPetDependencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = externalPersonPetDependencyException.Message });
            }
            catch (ExternalPersonPetServiceException externalPersonPetServiceException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Error = externalPersonPetServiceException.Message });
            }
        }

        [HttpGet("export/download")]
        public async ValueTask<ActionResult> DownloadPeopleWithPetsXml()
        {
            try
            {
                await this.personOrchestrationService.ExportAllPeopleWithPetsToXmlAsync();

                Stream xmlFileStream =
                    await this.personOrchestrationService.RetrievePeopleWithPetsXmlFileAsync();

                return File(xmlFileStream, "application/xml", "PeopleWithPets.xml");
            }
            catch (PersonDependencyException personDependencyException)
            {
                return InternalServerError(personDependencyException.InnerException);
            }
            catch (PersonServiceException personServiceException)
            {
                return InternalServerError(personServiceException.InnerException);
            }
        }
    }
}
