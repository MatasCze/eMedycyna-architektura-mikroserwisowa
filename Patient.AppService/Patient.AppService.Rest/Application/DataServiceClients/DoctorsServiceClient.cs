using Patient.AppService.Rest.Application.Dtos;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Patient.AppService.Rest.Application.DataServiceClients
{
    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        public IHttpClientFactory clientFactory;

        public DoctorsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<DoctorDto> GetDoctorBySpecializationAsync(string specialization)
        {
            //var url = $"https://localhost:44341/GetDoctorBySpecialization?specialization=";
            var url = Environment.GetEnvironmentVariable("doctorsServiceGetDoctorBySpecialization");

            var request = new HttpRequestMessage(HttpMethod.Get, url + specialization);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            DoctorDto doctor = null;
            try
            {
                doctor = await JsonSerializer.DeserializeAsync<DoctorDto>(responseStream, options);
            }
            catch (Exception)
            { }

            return doctor;
        }
    }
}
