namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class PatientsServiceClient : IPatientsServiceClient
    {
        public IHttpClientFactory clientFactory;

        public PatientsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }


        public async Task<IList<PatientDto>> GetAllPatientsAsync()
        {
            string url = Environment.GetEnvironmentVariable("patientsServiceGetAllPatients");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IList<PatientDto>>(responseStream, options);
        }

        public async Task<int> GetPatientIdByPesel(string pesel)
        {
            string url = Environment.GetEnvironmentVariable("patientsServiceGetPatientByPesel");

            var request = new HttpRequestMessage(HttpMethod.Get, url + pesel);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return (await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options)).Id;
        }
    }
}
