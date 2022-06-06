using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Prescriptions.Model;

namespace Prescriptions.Logic
{
    public class PrescriptionsFromXml : IPrescriptions
    {
        private static XmlDocument prescriptionsXmlDocument;

        private static readonly IList<Prescription> prescriptions;

        private static readonly object prescriptionLock = new object();

        private static Writer prescriptionWriter;

        private const string prescriptionXmlFilename = "database.xml";
        private const string prescriptionXsdFilename = "database.xsd";


        public PrescriptionsFromXml()
        {
        }

        static PrescriptionsFromXml()
        {
            lock (PrescriptionsFromXml.prescriptionLock)
            {
                Reader prescriptionsReader = new Reader();


                prescriptionsXmlDocument = prescriptionsReader.ReadDatabaseXml(prescriptionXmlFilename, prescriptionXsdFilename);

                prescriptions = prescriptionsReader.ReadPrescriptions(prescriptionsXmlDocument);

                prescriptionWriter = new Writer(prescriptionsXmlDocument);

            }
        }

        public Prescription[] GetAllPrescriptions()
        {
            lock (PrescriptionsFromXml.prescriptionLock)
            {
                return prescriptions.ToArray();
            }
        }

        public Prescription[] GetPrescription(int patientId)
        {
            lock (PrescriptionsFromXml.prescriptionLock)
            {
                List<Prescription> resultList = new List<Prescription>();
                foreach (Prescription prescription in prescriptions)
                {
                    if (prescription.PatientId.Equals(patientId))
                        resultList.Add(prescription);
                }

                return resultList.ToArray();
            }
        }

        public void AddPrescriptionToXmlDocument(Prescription prescription)
        {
            prescriptionWriter.AddPrescriptionToXmlDocument(prescription);
            prescriptions.Add(prescription);
        }

    }
}
