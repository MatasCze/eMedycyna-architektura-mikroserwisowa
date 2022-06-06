using System;
using System.Collections.Generic;

namespace Prescriptions.Rest.Model
{
    public class PrescriptionData
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string GivenAt { get; set; }
        public string ExpiryDate { get; set; }

        public IList<MedicineData> Medicines { get; set; } = new List<MedicineData>();
    }
}
