namespace Doctor.AppService.Rest.Application.Commands
{
    using Doctor.AppService.Rest.Application.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;

    public class PrescriptionsCommandsHandler : ICommandHandler<AddPrescriptionCommand>
    {
        public async void HandleAsync(AddPrescriptionCommand command)
        {
            using var client = new HttpClient();

            var json = JsonConvert.SerializeObject(new PrescriptionDto
            {
                Id = command.Id,
                DoctorId = command.DoctorId,
                PatientId = command.PatientId,
                GivenAt = DateTime.Now.ToString(),
                ExpiryDate = command.ExpiryDate,
                Medicines = command.Medicines
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = Environment.GetEnvironmentVariable("prescriptionsServiceAddPrescription");

            await client.PostAsync(url, data);
        }
    }
}
