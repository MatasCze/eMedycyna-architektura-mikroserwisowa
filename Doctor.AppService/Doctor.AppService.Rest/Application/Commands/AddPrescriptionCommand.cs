namespace Doctor.AppService.Rest.Application.Commands
{
    using Doctor.AppService.Rest.Application.Dtos;
    using System.Collections.Generic;

    public class AddPrescriptionCommand : ICommand
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string ExpiryDate { get; set; }

        public List<MedicineDto> Medicines { get; set; }
    }
}
