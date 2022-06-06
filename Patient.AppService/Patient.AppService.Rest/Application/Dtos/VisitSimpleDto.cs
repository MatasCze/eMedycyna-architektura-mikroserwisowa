namespace Patient.AppService.Rest.Application.Dtos
{
    public class VisitSimpleDto
    {
        public int PatientId { get; set; }

        public string Problem { get; set; }

        public string Date { get; set; }
    }
}
