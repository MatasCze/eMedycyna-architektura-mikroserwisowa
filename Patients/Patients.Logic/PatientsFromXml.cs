namespace Patients.Logic
{
    using Patients.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class PatientsFromXml : IPatient
    {
        private static XmlDocument patientsXmlDocument;

        private static readonly IList<Patient> patients;

        private static readonly object patientLock = new object();

        private const string patientsXmlFilename = "database.xml";
        private const string patientsXsdFilename = "database.xsd";

        static PatientsFromXml()
        {
            lock (PatientsFromXml.patientLock)
            {
                Reader patientsReader = new Reader();

                patientsXmlDocument = patientsReader.ReadDatabaseXml(patientsXmlFilename, patientsXsdFilename);

                patients = patientsReader.ReadPatients(patientsXmlDocument);
            }
        }

        public PatientsFromXml()
        {
        }

        public Patient[] GetAllPatients()
        {
            lock (PatientsFromXml.patientLock)
            {
                return patients.ToArray();
            }
        }

        public Patient GetPatientByPesel(string pesel)
        {
            lock (PatientsFromXml.patientLock)
            {

                foreach (Patient patient in patients)
                {
                    if (patient.Pesel.Equals(pesel)) return patient;

                }

                return null;

            }
        }

    }
}
