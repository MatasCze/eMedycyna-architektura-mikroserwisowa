namespace Patient.AppService.Rest.Application.Queries
{
    using Patient.AppService.Rest.Application.DataServiceClients;
    using Patient.AppService.Rest.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PatientWebServiceQueryHandler : IPatientWebServiceHandler
    {

        private readonly IPrescriptionsServiceClient prescriptionsServiceClient;
        private readonly IVisitsServiceClient visitsServiceClient;
        private readonly IPatientsServiceClient patientsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;

        public PatientWebServiceQueryHandler(IPrescriptionsServiceClient prescriptionsServiceClient, IVisitsServiceClient visitsServiceClient, IPatientsServiceClient patientsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            this.prescriptionsServiceClient = prescriptionsServiceClient;
            this.visitsServiceClient = visitsServiceClient;
            this.patientsServiceClient = patientsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync(int patientId)
        {
            var AllPrescriptions = prescriptionsServiceClient.GetAllPrescriptionsAsync(patientId);
            return await AllPrescriptions;
        }


        public async Task<IList<VisitToPatientDto>> GetAllVisitsAsync(int patientId)
        {
            var AllVisits = visitsServiceClient.GetAllVisitsAsync(patientId);
            return await AllVisits;
        }

        public async Task<VisitDto> GetMyVisit(VisitSimpleDto visit)
        {
            var doctor = await doctorsServiceClient.GetDoctorBySpecializationAsync(visit.Problem);
            if (doctor == null)
                return null;

            Random random = new Random();
            var room = random.Next(1, 10);

            VisitDto visitDto = new VisitDto()
            {
                Id = 1001,
                Date = visit.Date,
                PatientId = visit.PatientId,
                Problem = visit.Problem,
                DoctorId = doctor.Id,
                Room = room.ToString()
            };

            return visitDto;
        }

        public async Task<int> GetPatientIdAsync(string pesel)
        {
            return await patientsServiceClient.GetPatientIdAsync(pesel);
        }

    }
}
