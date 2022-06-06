using Patient.AppService.Rest.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.AppService.Rest.Application.DataServiceClients
{
    public interface IVisitsServiceClient
    {
        Task<IList<VisitToPatientDto>> GetAllVisitsAsync(int patientId);
    }
}
