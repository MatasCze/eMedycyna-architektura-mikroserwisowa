namespace Doctor.Application.Model
{
    public class VisitData
    {
        public int PatientId { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorLastName { get; set; }

        public string Problem { get; set; }

        public string Date { get; set; }

        public string Room { get; set; }
    }
}
