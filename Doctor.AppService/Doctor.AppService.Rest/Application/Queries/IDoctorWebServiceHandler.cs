namespace Doctor.AppService.Rest.Application.Queries
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDoctorWebServiceHandler
    {
        Task<IList<PatientDto>> GetAllPatientsAsync();

        Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync();

        Task<IList<VisitDto>> GetVisitsAsync(int doctorId);

        Task<IList<PrescriptionDto>> GetPrescriptionsAsync(string pesel);
    }
}
