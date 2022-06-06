using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prescriptions.Model;

namespace Prescriptions.Rest.Model
{
    public static class DataConverter
    {
        public static IList<MedicineData> ConvertToMedicineData(this IList<Medicine> medicines)
        {
            IList<MedicineData> medicineDataList = new List<MedicineData>();
            foreach (Medicine medicine in medicines)
            {
                medicineDataList.Add(new MedicineData() { Id = medicine.Id, Name = medicine.Name });
            }
            return medicineDataList;
        }

        public static IList<Medicine> ConvertToMedicine(this IList<MedicineData> medicinesData)
        {
            IList<Medicine> medicineList = new List<Medicine>();
            foreach (MedicineData medicineData in medicinesData)
            {
                medicineList.Add(new Medicine(medicineData.Id, medicineData.Name));
            }
            return medicineList;
        }

        public static PrescriptionData ConvertToPrescriptionData(this Prescription prescription)
        {
            return new PrescriptionData() { Id = prescription.Id, PatientId = prescription.PatientId, DoctorId = prescription.DoctorId, GivenAt = prescription.GivenAt, ExpiryDate = prescription.ExpiryDate, Medicines = ConvertToMedicineData(prescription.Medicines) };
        }

        public static Prescription ConvertToPrescription(this PrescriptionData prescription)
        {
            return new Prescription(prescription.Id, prescription.PatientId, prescription.DoctorId, prescription.GivenAt, prescription.ExpiryDate, ConvertToMedicine(prescription.Medicines));
        }
    }

}

