using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescriptions.Model
{
    public interface IPrescriptions
    {
        public Prescription[] GetAllPrescriptions();

        public Prescription[] GetPrescription(int patientId);

        public void AddPrescriptionToXmlDocument(Prescription prescription);
    }
}
