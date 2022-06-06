namespace Patient.AppService.Rest.Application.Commands
{
    public class AddVisitCommand : ICommand
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string Problem { get; set; }

        public string Date { get; set; }

        public string Room { get; set; }
    }
}
