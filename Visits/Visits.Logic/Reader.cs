namespace Visits.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;
    using Visits.Model;

    public class Reader
    {
        private const string networkNamespace = "net";
        private const string networkSchema = "http://tempuri.org/database.xsd";

        public XmlDocument ReadDatabaseXml(string xmlFilename, string xsdFilename)
        {
            if (String.IsNullOrWhiteSpace(xmlFilename) || String.IsNullOrWhiteSpace(xsdFilename))
                throw new ArgumentException();

            XmlDocument networkXmlDocument = new XmlDocument();

            XmlReaderSettings xmlReaderSettings = GetXmlReaderSettings(xsdFilename);

            using (XmlReader xmlReader = XmlReader.Create(xmlFilename, xmlReaderSettings))
            {
                networkXmlDocument.Load(xmlReader);
            }

            return networkXmlDocument;
        }

        private XmlReaderSettings GetXmlReaderSettings(string xsdFilename)
        {
            Debug.Assert(condition: !String.IsNullOrWhiteSpace(xsdFilename));

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

            xmlReaderSettings.Schemas.Add(null, xsdFilename);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);

            return xmlReaderSettings;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        public IList<Visit> ReadVisits(XmlDocument databaseXmlDocument)
        {
            List<Visit> visitList = new List<Visit>();

            XmlNamespaceManager xmlNamespaceManager = Reader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/net:Database/net:Visits/net:Visit");

            XmlNodeList visitXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in visitXmlNodes)
                visitList.Add(ConvertXmlElementToVisit(xmlElement, xmlNamespaceManager));

            return visitList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(networkNamespace, networkSchema);

            return xmlNamespaceManager;
        }

        private static Visit ConvertXmlElementToVisit(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string idAttribute = "id";
            const string doctorIdAttribute = "doctorId";
            const string patientIdAttribute = "patientId";
            const string problemAttribute = "problem";
            const string dateAttribute = "date";
            const string roomAttribute = "room";

            int id = int.Parse(xmlElement.GetAttribute(idAttribute));
            int doctorId = int.Parse(xmlElement.GetAttribute(doctorIdAttribute));
            int patientId = int.Parse(xmlElement.GetAttribute(patientIdAttribute));
            string problem = xmlElement.GetAttribute(problemAttribute);
            string date = xmlElement.GetAttribute(dateAttribute);
            string room = xmlElement.GetAttribute(roomAttribute);

            return new Visit(id, doctorId, patientId, problem, date, room);
        }

    }
}
