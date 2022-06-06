namespace Visits.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Visits.Model;

    public class VisitsFromXmlAndToXml : IVisits
    {
        private static XmlDocument visitsXmlDocument;

        private static readonly IList<Visit> visits;

        private static readonly object visitLock = new object();

        private static Writer visitsWriter;

        private const string visitsXmlFilename = "database.xml";
        private const string visitsXsdFilename = "database.xsd";

        static VisitsFromXmlAndToXml()
        {
            lock (VisitsFromXmlAndToXml.visitLock)
            {
                Reader visitsReader = new Reader();

                visitsXmlDocument = visitsReader.ReadDatabaseXml(visitsXmlFilename, visitsXsdFilename);

                visits = visitsReader.ReadVisits(visitsXmlDocument);

                visitsWriter = new Writer(visitsXmlDocument);
            }
        }

        public VisitsFromXmlAndToXml()
        {
        }

        public Visit[] GetAllVisits()
        {
            lock (VisitsFromXmlAndToXml.visitLock)
            {
                return visits.ToArray();
            }
        }

        public Visit[] GetVisits(int doctorId)
        {
            lock (VisitsFromXmlAndToXml.visitLock)
            {
                List<Visit> resultList = new List<Visit>();
                foreach(Visit visit in visits)
                {
                    if (visit.DoctorId == doctorId)
                        resultList.Add(visit);
                }
                return resultList.ToArray();
            }
        }

        public Visit[] GetVisitsPatient(int patientId)
        {
            lock (VisitsFromXmlAndToXml.visitLock)
            {
                List<Visit> resultList = new List<Visit>();
                foreach (Visit visit in visits)
                {
                    if (visit.PatientId == patientId)
                        resultList.Add(visit);
                }
                return resultList.ToArray();
            }
        }

        public void AddVisit(Visit visit)
        {
            visitsWriter.AddVisitToXmlDocument(visit);
            visits.Add(visit);
        }
    }
}
