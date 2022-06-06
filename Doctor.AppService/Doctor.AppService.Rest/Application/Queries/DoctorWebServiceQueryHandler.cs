namespace Doctor.AppService.Rest.Application.Queries
{
    using Doctor.AppService.Rest.Application.DataServiceClients;
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DoctorWebServiceQueryHandler : IDoctorWebServiceHandler
    {
        private readonly IPatientsServiceClient patientsServiceClient;

        private readonly IPrescriptionsServiceClient prescriptionsServiceClient;

        private readonly IVisitsServiceClient visitsServiceClient;

        public DoctorWebServiceQueryHandler(IPatientsServiceClient patientsServiceClient, IPrescriptionsServiceClient prescriptionsServiceClient, IVisitsServiceClient visitsServiceClient)
        {
            this.patientsServiceClient = patientsServiceClient;
            this.prescriptionsServiceClient = prescriptionsServiceClient;
            this.visitsServiceClient = visitsServiceClient;
        }

        public async Task<IList<PatientDto>> GetAllPatientsAsync()
        {
            return await patientsServiceClient.GetAllPatientsAsync();
        }

        public async Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            return await prescriptionsServiceClient.GetAllPrescriptionsAsync();
        }

        public async Task<IList<PrescriptionDto>> GetPrescriptionsAsync(string pesel)
        {
            int patientId = await patientsServiceClient.GetPatientIdByPesel(pesel);
            return await prescriptionsServiceClient.GetPrescriptionsAsync(patientId);
        }

        public async Task<IList<VisitDto>> GetVisitsAsync(int doctorId)
        {
            return await visitsServiceClient.GetVisitsAsync(doctorId);
        }
    }
}
