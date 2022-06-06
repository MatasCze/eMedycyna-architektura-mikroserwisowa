namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPatientsServiceClient
    {
        Task<IList<PatientDto>> GetAllPatientsAsync();

        Task<int> GetPatientIdByPesel(string pesel);

    }
}
