namespace Patients.Logic
{
    using global::Patients.Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;

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

        public IList<Patient> ReadPatients(XmlDocument databaseXmlDocument)
        {
            List<Patient> patientList = new List<Patient>();

            XmlNamespaceManager xmlNamespaceManager = Reader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/net:Database/net:Patients/net:Patient");

            XmlNodeList patientXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in patientXmlNodes)
                patientList.Add(ConvertXmlElementToPatient(xmlElement, xmlNamespaceManager));

            return patientList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(networkNamespace, networkSchema);

            return xmlNamespaceManager;
        }

        private static Patient ConvertXmlElementToPatient(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {

            const string idAttribute = "id";
            const string peselAttribute = "pesel";
            const string lastNameAttribute = "lastName";
            const string firstNameAttribute = "firstName";

            int id = int.Parse(xmlElement.GetAttribute(idAttribute));
            string pesel = xmlElement.GetAttribute(peselAttribute);
            string lastName = xmlElement.GetAttribute(lastNameAttribute);
            string firstName = xmlElement.GetAttribute(firstNameAttribute);

            return new Patient(id, pesel, lastName, firstName);
        }

    }
}
