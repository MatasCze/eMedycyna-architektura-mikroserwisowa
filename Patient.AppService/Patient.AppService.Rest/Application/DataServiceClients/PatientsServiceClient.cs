namespace Patient.AppService.Rest.Application.DataServiceClients
{
    using Patient.AppService.Rest.Application.Dtos;
    using System;
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

        public async Task<int> GetPatientIdAsync(string pesel)
        {
            var url = Environment.GetEnvironmentVariable("patientsServiceGetPatientByPesel");

            var request = new HttpRequestMessage(HttpMethod.Get, url + pesel);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var patient = await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options);
            
            return patient.Id;
        }
    }
}