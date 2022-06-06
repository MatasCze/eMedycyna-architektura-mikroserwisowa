namespace Doctors.Logic
{
    using global::Doctors.Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;

    public class Reader
    {
        private const string databaseNamespace = "net";
        private const string databaseSchema = "http://tempuri.org/database.xsd";

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

        public IList<Doctor> ReadDoctors(XmlDocument databaseXmlDocument)
        {
            List<Doctor> doctorList = new List<Doctor>();

            XmlNamespaceManager xmlNamespaceManager = Reader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/net:Database/net:Doctors/net:Doctor");

            XmlNodeList doctorXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in doctorXmlNodes)
                doctorList.Add(ConvertXmlElementToDoctor(xmlElement, xmlNamespaceManager));

            return doctorList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(databaseNamespace, databaseSchema);

            return xmlNamespaceManager;
        }

        private static Doctor ConvertXmlElementToDoctor(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string specializationsElement = "net:Specializations";

            const string idAttribute = "id";
            const string firstNameAttribute = "firstName";
            const string lastNameAttribute = "lastName";
            const string peselAttribute = "pesel";
            const string nameAttribute = "name";

            int idDoctor = int.Parse(xmlElement.GetAttribute(idAttribute));
            string firstName = xmlElement.GetAttribute(firstNameAttribute);
            string lastName = xmlElement.GetAttribute(lastNameAttribute);
            string pesel = xmlElement.GetAttribute(peselAttribute);

            IList<Specialization> specializationList = new List<Specialization>();
            XmlElement specializationsXmlElement = xmlElement.SelectSingleNode(specializationsElement, xmlNamespaceManager) as XmlElement;
            foreach (XmlElement specialization in specializationsXmlElement)
            {
                int id = int.Parse(specialization.GetAttribute(idAttribute));
                string name = specialization.GetAttribute(nameAttribute);
                specializationList.Add(new Specialization(id, name));
            }

            return new Doctor(idDoctor, firstName, lastName, pesel, specializationList);
        }

    }
}
