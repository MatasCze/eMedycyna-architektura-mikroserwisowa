namespace Patient.AppService.Rest.Application.Commands
{
    using Newtonsoft.Json;
    using Patient.AppService.Rest.Application.Dtos;
    using System;
    using System.Net.Http;
    using System.Text;

    public class VisitsCommandsHandler : ICommandHandler<AddVisitCommand>
    {
        public async void HandleAsync(AddVisitCommand command)
        {
            if (command != null)
            {
                using var client = new HttpClient();

                var json = JsonConvert.SerializeObject(new VisitDto
                {
                    Id = command.Id,
                    DoctorId = command.DoctorId,
                    PatientId = command.PatientId,
                    Date = command.Date,
                    Problem = command.Problem,
                    Room = command.Room
                });

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = Environment.GetEnvironmentVariable("visitsServiceAddVisit");

                await client.PostAsync(url, data);
            }
        }
    }
}
