namespace Doctor.Application.Model
{
    public interface INetwork
    {
        PrescriptionData[] GetPrescriptions(string pesel);

        VisitData[] GetVisits(int doctorId);

        int GetDoctorId(string pesel);

        void AddPrescription(PrescriptionData prescription);
    }
}
