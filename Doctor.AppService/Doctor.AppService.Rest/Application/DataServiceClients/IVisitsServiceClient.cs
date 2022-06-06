namespace Doctor.AppService.Rest.Application.DataServiceClients
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IVisitsServiceClient
    {
        Task<IList<VisitDto>> GetVisitsAsync(int doctorId);
    }
}
