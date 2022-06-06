namespace Patient.AppService.Rest.Application.Dtos
{
    public class VisitToPatientDto
    {
        public string DoctorFirstName { get; set; }

        public string DoctorLastName { get; set; }

        public string Problem { get; set; }

        public string Date { get; set; }

        public string Room { get; set; }
    }
}
