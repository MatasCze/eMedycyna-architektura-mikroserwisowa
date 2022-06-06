namespace Doctor.WindowsApplication.Logic.Model
{
    public interface INetwork
    {
        PrescriptionData[] GetPrescriptions(string peselText);

        int GetPatientId(string pesel);

        VisitData[] GetVisits(int patientId);
    }
}
