namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class VisitsServiceClient : IVisitsServiceClient
    {
        public IHttpClientFactory clientFactory;

        public VisitsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IList<VisitDto>> GetVisitsAsync(int doctorId)
        {
            string url = Environment.GetEnvironmentVariable("visitsServiceGetVisits");

            var request = new HttpRequestMessage(HttpMethod.Get, url + doctorId);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IList<VisitDto>>(responseStream, options);
        }

    }
}
