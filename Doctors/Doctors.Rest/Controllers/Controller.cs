namespace Doctors.Rest
{
    using Doctors.Logic;
    using Doctors.Model;
    using Doctors.Rest.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase, IDoctorsService
    {
        private readonly ILogger<Controller> logger;

        private readonly IDoctors doctors;

        public Controller(ILogger<Controller> logger)
        {
            this.logger = logger;
            doctors = new Doctors();
        }

        [HttpGet]
        [Route("GetAllDoctors")]
        public DoctorData[] GetAllDoctors()
        {
            Doctor[] doctorArray = doctors.GetAllDoctors();
            return doctorArray.Select(doctor => doctor.ConvertToDoctorData()).ToArray();
        }

        [HttpGet]
        [Route("GetDoctor")]
        public DoctorSimpleData[] GetDoctor(string lastName)
        {
            Doctor[] doctorArray = doctors.GetDoctor(lastName);
            return doctorArray.Select(doctor => doctor.ConvertToDoctorSimpleData()).ToArray();
        }

        [HttpGet]
        [Route("GetDoctorById")]
        public DoctorSimpleData GetDoctor(int doctorId)
        {
            Doctor doctor = doctors.GetDoctor(doctorId);
            return doctor.ConvertToDoctorSimpleData();
        }

        [HttpGet]
        [Route("GetDoctorBySpecialization")]
        public DoctorData GetDoctorBySpecialization(string specialization)
        {
            Doctor doctor = doctors.GetDoctorBySpecialization(specialization);
            return doctor.ConvertToDoctorData();
        }
    }
}
