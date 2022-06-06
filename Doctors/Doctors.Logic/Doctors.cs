namespace Doctors.Logic
{
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class Doctors : IDoctors
    {
        private static XmlDocument doctorsXmlDocument;

        private static readonly IList<Doctor> doctors;

        private static readonly object doctorLock = new object();

        private const string doctorsXmlFilename = "database.xml";
        private const string doctorsXsdFilename = "database.xsd";

        static Doctors()
        {
            lock (Doctors.doctorLock)
            {
                Reader doctorsReader = new Reader();

                doctorsXmlDocument = doctorsReader.ReadDatabaseXml(doctorsXmlFilename, doctorsXsdFilename);

                doctors = doctorsReader.ReadDoctors(doctorsXmlDocument);
            }
        }

        public Doctors()
        {
        }

        public Doctor[] GetAllDoctors()
        {
            lock (Doctors.doctorLock)
            {
                return doctors.ToArray();
            }
        }

        public Doctor[] GetDoctor(string lastName)
        {
            if (lastName != null && !lastName.Equals(""))
            {
                lock (Doctors.doctorLock)
                {
                    List<Doctor> resultList = new List<Doctor>();
                    foreach (Doctor doctor in doctors)
                    {
                        if (doctor.LastName.ToLower().Equals(lastName.ToLower()))
                            resultList.Add(doctor);
                    }

                    return resultList.ToArray();
                }
            }
            else
                return new Doctor[] { };
        }

        public Doctor GetDoctor(int doctorId)
        {

            lock (Doctors.doctorLock)
            {
                List<Doctor> resultList = new List<Doctor>();
                foreach (Doctor doctor in doctors)
                {
                    if (doctor.Id == doctorId)
                        resultList.Add(doctor);
                }

                if(resultList.Count != 0)
                    return resultList.ToArray()[0];
                return null;
            }

        }

        public Doctor GetDoctorBySpecialization(string specialization)
        {
            if (specialization == null)
                return null;
            lock (Doctors.doctorLock)
            {
                foreach(Doctor doctor in doctors)
                {
                    foreach(Specialization spec in doctor.Specializations)
                    {
                        if (spec.Name.ToLower().Equals(specialization.ToLower()))
                            return doctor;
                    }
                }
            }
            return null;
        }
    }
}
