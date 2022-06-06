namespace Patient.AppService.Rest
{
    using Patient.AppService.Rest.Application.Commands;
    using Patient.AppService.Rest.Application.DataServiceClients;
    using Patient.AppService.Rest.Application.Queries;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "Patient.AppService", Version = "v1" }); });
            services.AddHttpClient();
            services.AddTransient<IPrescriptionsServiceClient, PrescriptionsServiceClient>();
            services.AddTransient<IPatientWebServiceHandler, PatientWebServiceQueryHandler>();
            services.AddTransient<IVisitsServiceClient, VisitsServiceClient>();
            services.AddTransient<IPatientsServiceClient, PatientsServiceClient>();
            services.AddTransient<ICommandHandler<AddVisitCommand>, VisitsCommandsHandler>();
            services.AddTransient<IDoctorsServiceClient, DoctorsServiceClient>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Patient.AppService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
