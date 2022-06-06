namespace Patients.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Patients.Logic;
    using Patients.Model;
    using Patients.Rest.Model;
    using Patients.Rest.Model.Model;
    using Patients.Rest.Model.Services;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase, IPatientsService
    {
        private readonly ILogger<Controller> logger;

        private readonly IPatient patients;

        public Controller(ILogger<Controller> logger)
        {
            this.logger = logger;
            patients = new PatientsFromXml();
        }

        [HttpGet]
        [Route("GetAllPatients")]
        public PatientData[] GetAllPatients()
        {
            Patient[] patientArray = patients.GetAllPatients();
            return patientArray.Select(patient => patient.ConvertToPatientData()).ToArray();
        }

        [HttpGet]
        [Route("GetPatientByPesel")]
        public PatientData GetPatientByPesel(string pesel)
        {
            Patient patient = patients.GetPatientByPesel(pesel);
            return patient.ConvertToPatientData();
        }


    }
}
