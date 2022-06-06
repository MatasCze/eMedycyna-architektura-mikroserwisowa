namespace Doctor.AppService.Rest.Application.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string Pesel { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

    }
}
