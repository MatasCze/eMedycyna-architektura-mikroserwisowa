namespace Patient.AppService.Rest.Application.DataServiceClients
{
    using Patient.AppService.Rest.Application.Dtos;
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

        public async Task<IList<VisitToPatientDto>> GetAllVisitsAsync(int patientId)
        {
            var url = Environment.GetEnvironmentVariable("visitsServiceGetVisitsPatient");

            var request = new HttpRequestMessage(HttpMethod.Get, url + patientId);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var visits = await JsonSerializer.DeserializeAsync<IList<VisitDto>>(responseStream, options);

            var resultList = new List<VisitToPatientDto>();


            foreach (VisitDto visit in visits)
            {
                DoctorDto doctor = null;

                doctor = await this.GetDoctorAsync(visit.DoctorId);

                resultList.Add(new VisitToPatientDto()
                {
                    DoctorFirstName = doctor.FirstName,
                    DoctorLastName = doctor.LastName,
                    Date = visit.Date,
                    Problem = visit.Problem,
                    Room = visit.Room
                });

            };

            return resultList;
        }

        private async Task<DoctorDto> GetDoctorAsync(int doctorId)
        {
            var url = Environment.GetEnvironmentVariable("doctorsServiceGetDoctorById");

            var request = new HttpRequestMessage(HttpMethod.Get, url + doctorId);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var doctor = await JsonSerializer.DeserializeAsync<DoctorDto>(responseStream, options);

            return doctor;
        }
    }
}
