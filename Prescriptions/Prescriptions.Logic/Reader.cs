using Prescriptions.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Prescriptions.Logic
{
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
            Debug.Assert(condition: !string.IsNullOrWhiteSpace(xsdFilename));

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

        public IList<Prescription> ReadPrescriptions(XmlDocument databaseXmlDocument)
        {
            List<Prescription> prescriptionList = new List<Prescription>();

            XmlNamespaceManager xmlNamespaceManager = GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = string.Format("/net:Database/net:Prescriptions/net:Prescription");

            XmlNodeList prescriptionXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in prescriptionXmlNodes)
                prescriptionList.Add(ConvertXmlElementToPrescription(xmlElement, xmlNamespaceManager));

            return prescriptionList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(networkNamespace, networkSchema);

            return xmlNamespaceManager;
        }

        private static Prescription ConvertXmlElementToPrescription(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string medicineElement = "net:Medicines";

            const string idAttribute = "id";
            const string patientIdAttribute = "patientId";
            const string doctorIdAttribute = "doctorId";
            const string givenAtAttribute = "givenAt";
            const string expiryDateAttribute = "expiryDate";

            const string nameAttribute = "name";



            int idPrescription = int.Parse(xmlElement.GetAttribute(idAttribute));
            int patientId = int.Parse(xmlElement.GetAttribute(patientIdAttribute));
            int doctorId = int.Parse(xmlElement.GetAttribute(doctorIdAttribute));
            string givenAt = xmlElement.GetAttribute(givenAtAttribute);
            string expiryDate = xmlElement.GetAttribute(expiryDateAttribute);


            IList<Medicine> medicineList = new List<Medicine>();
            XmlElement medicineXmlElement = xmlElement.SelectSingleNode(medicineElement, xmlNamespaceManager) as XmlElement;
            foreach (XmlElement medicine in medicineXmlElement)
            {
                int id = int.Parse(medicine.GetAttribute(idAttribute));
                string name = medicine.GetAttribute(nameAttribute);
                medicineList.Add(new Medicine(id, name));
            }

            return new Prescription(idPrescription, patientId, doctorId, givenAt, expiryDate, medicineList);

        }
    }
}
