namespace Patient.AppService.Rest.Application.DataServiceClients
{
    using Patient.AppService.Rest.Application.Dtos;
    using System.Threading.Tasks;

    public interface IDoctorsServiceClient
    {
        Task<DoctorDto> GetDoctorBySpecializationAsync(string specialization);
    }
}
