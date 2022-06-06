namespace Doctor.AppService.Rest
{
    using Doctor.AppService.Rest.Application.Commands;
    using Doctor.AppService.Rest.Application.DataServiceClients;
    using Doctor.AppService.Rest.Application.Queries;
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
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "Doctor.AppService", Version = "v1" }); });
            services.AddHttpClient();
            services.AddTransient<IPrescriptionsServiceClient, PrescriptionsServiceClient>();
            services.AddTransient<IPatientsServiceClient, PatientsServiceClient>();
            services.AddTransient<IVisitsServiceClient, VisitsServiceClient>();
            services.AddTransient<IDoctorWebServiceHandler, DoctorWebServiceQueryHandler>();
            services.AddTransient<ICommandHandler<AddPrescriptionCommand>, PrescriptionsCommandsHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Doctor.AppService v1"));
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
