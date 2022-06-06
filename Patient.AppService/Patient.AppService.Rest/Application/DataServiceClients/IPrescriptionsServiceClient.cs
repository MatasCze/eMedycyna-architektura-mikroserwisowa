namespace Patient.AppService.Rest.Application.DataServiceClients
{
    using Patient.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPrescriptionsServiceClient
    {
        Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync(int patientId);
    }
}
