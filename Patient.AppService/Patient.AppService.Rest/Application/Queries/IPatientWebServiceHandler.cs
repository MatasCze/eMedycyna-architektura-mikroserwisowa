namespace Patient.AppService.Rest.Application.Queries
{
    using Patient.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPatientWebServiceHandler
    {

        Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync(int patientId);

        Task<IList<VisitToPatientDto>> GetAllVisitsAsync(int patientId);

        Task<int> GetPatientIdAsync(string pesel);

        Task<VisitDto> GetMyVisit(VisitSimpleDto visit);

    }
}
