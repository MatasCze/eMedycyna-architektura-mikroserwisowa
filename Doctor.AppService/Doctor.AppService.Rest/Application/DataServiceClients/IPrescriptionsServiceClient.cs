namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPrescriptionsServiceClient
    {
        Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync();

        Task<IList<PrescriptionDto>> GetPrescriptionsAsync(int patientId);
    }
}
