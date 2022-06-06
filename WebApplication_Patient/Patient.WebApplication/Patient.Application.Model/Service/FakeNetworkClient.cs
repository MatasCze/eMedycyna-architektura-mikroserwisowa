namespace Patient.Application.Model
{
    using System.Collections.Generic;

    public class FakeNetworkClient : INetwork
    {
        private static readonly PrescriptionData[] prescriptions =
            new PrescriptionData[] { new PrescriptionData() { Id=1, DoctorId=1, PatientId=1, ExpiryDate="15.06.2021", GivenAt="12.05.2021",
                Medicines = new MedicineData[]{ new MedicineData() { Id=1, Name="Apap"} } } };

        private static readonly List<VisitData> visits =
            new List<VisitData> { new VisitData() { DoctorFirstName = "Jan", DoctorLastName = "Kowalski", Date = "12.06.2021", Room = "10a", Problem = "Alergologia" },
            new VisitData() {DoctorFirstName = "Paweł", DoctorLastName = "Kucharski", Date = "25.07.2021", Room = "12", Problem = "Okulistyka"} };

        public void AddVisit(VisitData visit)
        {
            visit.DoctorFirstName = "Jan";
            visit.DoctorLastName = "Kowalski";
            visit.Room = "101";
            visits.Add(visit);
        }

        public int GetPatientId(string pesel)
        {
            return 1;
        }

        public PrescriptionData[] GetPrescriptions(int patientId)
        {
            return FakeNetworkClient.prescriptions;
        }

        public VisitData[] GetVisits(int patientId)
        {
            return FakeNetworkClient.visits.ToArray();
        }
    }
}
