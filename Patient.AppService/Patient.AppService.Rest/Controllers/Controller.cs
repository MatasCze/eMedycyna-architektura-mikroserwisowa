namespace Patient.AppService.Rest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Patient.AppService.Rest.Application.Commands;
    using Patient.AppService.Rest.Application.Dtos;
    using Patient.AppService.Rest.Application.Mapper;
    using Patient.AppService.Rest.Application.Queries;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> logger;
        private readonly IPatientWebServiceHandler patientWebServiceHandler;
        private readonly ICommandHandler<AddVisitCommand> addVisitCommandHandler;

        public Controller(ILogger<Controller> logger, IPatientWebServiceHandler patientWebServiceHandler, ICommandHandler<AddVisitCommand> addVisitCommandHandler)
        {
            this.logger = logger;
            this.patientWebServiceHandler = patientWebServiceHandler;
            this.addVisitCommandHandler = addVisitCommandHandler;
        }

        [HttpGet("GetAllPrescriptions")]
        public async Task<IList<PrescriptionDto>> GetAllPrescriptionsAsync(int patientId)
        {
            return await patientWebServiceHandler.GetAllPrescriptionsAsync(patientId);
        }


        [HttpGet("GetAllVisits")]
        public async Task<IList<VisitToPatientDto>> GetAllVisitsAsync(int patientId)
        {
            return await patientWebServiceHandler.GetAllVisitsAsync(patientId);
        }

        [HttpGet("GetPatientId")]
        public async Task<int> GetPatientIdAsync(string pesel)
        {
            return await patientWebServiceHandler.GetPatientIdAsync(pesel);
        }

        [HttpPost("AddVisit")]
        public async void AddPrescription([FromBody] VisitSimpleDto visit)
        {
            var visitDto = await patientWebServiceHandler.GetMyVisit(visit);

            addVisitCommandHandler.HandleAsync(visitDto.Map());
        }


    }
}
