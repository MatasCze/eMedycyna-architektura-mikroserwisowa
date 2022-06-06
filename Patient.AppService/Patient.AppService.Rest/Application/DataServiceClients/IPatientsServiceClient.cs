namespace Patient.AppService.Rest.Application.DataServiceClients
{
    using System.Threading.Tasks;

    public interface IPatientsServiceClient
    {
        Task<int> GetPatientIdAsync(string pesel);
    }
}
