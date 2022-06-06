using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prescriptions.Logic;
using Prescriptions.Model;
using Prescriptions.Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prescriptions.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase, IPrescriptionService
    {
        private readonly ILogger<Controller> logger;

        private readonly IPrescriptions prescriptions;

        public Controller(ILogger<Controller> logger)
        {
            this.logger = logger;
            prescriptions = new PrescriptionsFromXml();
        }

        [HttpGet]
        [Route("GetAllPrescriptions")]
        public PrescriptionData[] GetAllPrescriptions()
        {
            Prescription[] prescriptionArray = prescriptions.GetAllPrescriptions();
            return prescriptionArray.Select(prescription => prescription.ConvertToPrescriptionData()).ToArray();
        }

        [HttpGet]
        [Route("GetPrescription")]
        public PrescriptionData[] GetPrescription(int patientId)
        {
            Prescription[] prescriptionArray = prescriptions.GetPrescription(patientId);
            return prescriptionArray.Select(prescription => prescription.ConvertToPrescriptionData()).ToArray();
        }

        [HttpPost]
        [Route("AddPrescription")]
        public void AddPrescription(PrescriptionData prescriptionData)
        {
            prescriptions.AddPrescriptionToXmlDocument(prescriptionData.ConvertToPrescription());
        }

    }
}
