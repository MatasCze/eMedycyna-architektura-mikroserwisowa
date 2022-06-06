namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class PrescriptionsServiceClient : IPrescriptionsServiceClient
    {
        public IHttpClientFactory clientFactory;

        public PrescriptionsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            string url = Environment.GetEnvironmentVariable("prescriptionsServiceGetAllPrescriptions");

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IList<PrescriptionDto>>(responseStream, options);
        }

        public async Task<IList<PrescriptionDto>> GetPrescriptionsAsync(int patientId)
        {
            string url = Environment.GetEnvironmentVariable("prescriptionsServiceGetPrescription");

            var request = new HttpRequestMessage(HttpMethod.Get, url + patientId);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IList<PrescriptionDto>>(responseStream, options);
        }

    }
}
