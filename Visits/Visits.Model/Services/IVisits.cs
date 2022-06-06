namespace Visits.Model
{
    public interface IVisits
    {
        public Visit[] GetAllVisits();

        public Visit[] GetVisits(int doctorId);

        public Visit[] GetVisitsPatient(int patientId);

        public void AddVisit(Visit visit);
    }
}
