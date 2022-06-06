namespace Doctor.AppService.Rest.Application.Dtos
{
    using System.Collections.Generic;

    public class PrescriptionDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string GivenAt { get; set; }

        public string ExpiryDate { get; set; }

        public List<MedicineDto> Medicines { get; set; }

    }
}
