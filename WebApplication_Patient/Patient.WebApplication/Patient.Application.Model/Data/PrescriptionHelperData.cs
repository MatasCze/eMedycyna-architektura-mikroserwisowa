namespace Patient.Application.Model
{
    public class PrescriptionHelperData
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string GivenAt { get; set; }

        public string ExpiryDate { get; set; }

        public string Medicines { get; set; }
    }
}
