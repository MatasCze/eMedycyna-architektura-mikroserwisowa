namespace Doctor.AppService.Rest.Controllers
{
    using Doctor.AppService.Rest.Application.Commands;
    using Doctor.AppService.Rest.Application.Dtos;
    using Doctor.AppService.Rest.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> logger;
        private readonly IDoctorWebServiceHandler doctorWebServiceHandler;
        private readonly ICommandHandler<AddPrescriptionCommand> addPrescriptionCommandHandler;

        public Controller(ILogger<Controller> logger, IDoctorWebServiceHandler doctorWebServiceHandler, ICommandHandler<AddPrescriptionCommand> addPrescriptionCommandHandler)
        {
            this.logger = logger;
            this.doctorWebServiceHandler = doctorWebServiceHandler;
            this.addPrescriptionCommandHandler = addPrescriptionCommandHandler;
        }

        [HttpGet("GetAllPatients")]
        public async Task<IList<PatientDto>> GetAllPatients()
        {
            return await doctorWebServiceHandler.GetAllPatientsAsync();
        }

        [HttpGet("GetAllPrescriptions")]
        public async Task<IList<PrescriptionDto>> GetAllPrescriptions()
        {
            return await doctorWebServiceHandler.GetAllPrescriptionsAsync();
        }

        [HttpGet("GetPrescriptions")]
        public async Task<IList<PrescriptionDto>> GetPrescriptions(string pesel)
        {
            return await doctorWebServiceHandler.GetPrescriptionsAsync(pesel);
        }

        [HttpPost("AddPrescription")]
        public void AddPrescription([FromBody] AddPrescriptionCommand prescriptionCommand)
        {
            addPrescriptionCommandHandler.HandleAsync(prescriptionCommand);
        }

        [HttpGet("GetVisits")]
        public async Task<IList<VisitDto>> GetVisits(int doctorId)
        {
            return await doctorWebServiceHandler.GetVisitsAsync(doctorId);
        }
    }
}
