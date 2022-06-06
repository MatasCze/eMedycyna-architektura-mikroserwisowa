namespace Visits.Rest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using Visits.Logic;
    using Visits.Model;
    using Visits.Rest.Model;
    using Visits.Rest.Model.Services;

    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase, IVisitsService
    {
        private readonly ILogger<Controller> logger;

        private readonly IVisits visits;

        public Controller(ILogger<Controller> logger)
        {
            this.logger = logger;
            visits = new VisitsFromXmlAndToXml();
        }

        [HttpGet]
        [Route("GetAllVisits")]
        public VisitData[] GetAllVisits()
        {
            Visit[] visitArray = visits.GetAllVisits();
            return visitArray.Select(visit => visit.ConvertToVisitData()).ToArray();
        }

        [HttpGet]
        [Route("GetVisits")]
        public VisitData[] GetVisits(int doctorId)
        {
            Visit[] visitArray = visits.GetVisits(doctorId);
            return visitArray.Select(visit => visit.ConvertToVisitData()).ToArray();
        }

        [HttpGet]
        [Route("GetVisitsPatient")]
        public VisitData[] GetVisitsPatient(int patientId)
        {
            Visit[] visitArray = visits.GetVisitsPatient(patientId);
            return visitArray.Select(visit => visit.ConvertToVisitData()).ToArray();
        }

        [HttpPost]
        [Route("AddVisit")]
        public void AddVisit(VisitData visitData)
        {
            visits.AddVisit(visitData.ConvertToVisit());
        }
    }
}
