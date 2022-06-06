namespace Visits.Rest.Model.Services
{
    public interface IVisitsService
    {
        public VisitData[] GetAllVisits();

        public VisitData[] GetVisits(int doctorId);

        public VisitData[] GetVisitsPatient(int patientId);

        public void AddVisit(VisitData visitData);

    }
}
