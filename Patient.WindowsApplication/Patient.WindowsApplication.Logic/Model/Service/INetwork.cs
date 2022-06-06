namespace Patient.WindowsApplication.Model
{
    public interface INetwork
    {
        PrescriptionData[] GetPrescriptions(int patientId);

        int GetPatientId(string pesel);

        VisitData[] GetVisits(int patientId);

        void AddVisit(VisitData visit);
    }
}
