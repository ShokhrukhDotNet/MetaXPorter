//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Text.Json.Serialization;
using MetaXPorter.Api.Brokers.Loggings;
using MetaXPorter.Api.Brokers.Queues;
using MetaXPorter.Api.Brokers.Sheets;
using MetaXPorter.Api.Brokers.Storages;
using MetaXPorter.Api.Services.Coordinations;
using MetaXPorter.Api.Services.Foundations.ExternalPersonPets;
using MetaXPorter.Api.Services.Foundations.Persons;
using MetaXPorter.Api.Services.Foundations.Pets;
using MetaXPorter.Api.Services.Orchestrations.ExternalPersonPets;
using MetaXPorter.Api.Services.Orchestrations.PersonPets;
using MetaXPorter.Api.Services.Orchestrations.Persons;
using MetaXPorter.Api.Services.Processings.ExternalPersonPets;
using MetaXPorter.Api.Services.Processings.Persons;
using MetaXPorter.Api.Services.Processings.Pets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MetaXPorter.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "MetaXPorter.Api",
                Version = "v1",
            };

            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddDbContext<StorageBroker>();
            AddBrokers(services);
            AddFoundationServices(services);
            AddProcessingServices(services);
            AddOrchestrationServices(services);
            AddCoordinationServices(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: apiInfo);
            });
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<ISheetBroker, SheetBroker>();
            services.AddTransient<IQueueBroker, QueueBroker>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetService, ExternalPersonPetService>();
            services.AddTransient<IExternalPersonPetEventService, ExternalPersonPetEventService>();
            services.AddTransient<IExternalPersonPetInputService, ExternalPersonPetInputService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonXMLService, PersonXMLService>();
            services.AddTransient<IPetService, PetService>();
        }

        private static void AddProcessingServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetProcessingService, ExternalPersonPetProcessingService>();
            services.AddTransient<IExternalPersonPetEventProcessingService, ExternalPersonPetEventProcessingService>();
            services.AddTransient<IExternalPersonPetInputProcessingService, ExternalPersonPetInputProcessingService>();

            services.AddTransient<IPersonProcessingService, PersonProcessingService>();
            services.AddTransient<IPersonXMLProcessingService, PersonXMLProcessingService>();
            services.AddTransient<IPetProcessingService, PetProcessingService>();
        }

        private static void AddOrchestrationServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonPetOrchestrationService, ExternalPersonPetOrchestrationService>();
            services.AddTransient<IExternalPersonPetEventOrchestrationService, ExternalPersonPetEventOrchestrationService>();
            services.AddTransient<IPersonPetOrchestrationService, PersonPetOrchestrationService>();
            services.AddTransient<IPersonOrchestrationService, PersonOrchestrationService>();
        }

        private static void AddCoordinationServices(IServiceCollection services) =>
            services.AddTransient<IPersonPetEventCoordinationService, PersonPetEventCoordinationService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "MetaXPorter.Api v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
