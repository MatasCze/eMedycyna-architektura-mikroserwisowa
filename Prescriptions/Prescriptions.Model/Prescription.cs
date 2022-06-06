using System;
using System.Collections.Generic;

namespace Prescriptions.Model
{
    public class Prescription
    {
        public int Id { get; private set; }

        public int PatientId { get; private set; }

        public int DoctorId { get; private set; }

        public string GivenAt { get; private set; }
        public string ExpiryDate { get; private set; }

        public IList<Medicine> Medicines { get; private set; } = new List<Medicine>();


        public Prescription(int id, int patientId, int doctorId, string givenAt, string expiryDate)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            GivenAt = givenAt;
            ExpiryDate = expiryDate;
        }

        public Prescription(int id, int patientId, int doctorId, string givenAt, string expiryDate, IList<Medicine> medicines) : this(id, patientId, doctorId, givenAt, expiryDate)
        {
            Medicines = medicines;
        }

        public void AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);
        }

        public void AddSpecializations(IEnumerable<Medicine> medicines)
        {
            foreach (var medicine in medicines)
                Medicines.Add(medicine);
        }
    }
}
