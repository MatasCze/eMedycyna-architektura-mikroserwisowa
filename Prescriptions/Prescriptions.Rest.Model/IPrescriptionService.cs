using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescriptions.Rest.Model
{
    public interface IPrescriptionService
    {
        public PrescriptionData[] GetAllPrescriptions();

        public PrescriptionData[] GetPrescription(int patientId);

        public void AddPrescription(PrescriptionData prescriptionData);

    }
}
