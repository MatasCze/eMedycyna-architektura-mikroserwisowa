using Prescriptions.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Prescriptions.Logic
{
    public class Writer
    {


        private const string networkNamespace = "net";
        private const string networkSchema = "http://tempuri.org/database.xsd";

        private static XmlDocument xmlDocument;

        private static XPathNavigator navigator;

        public Writer(XmlDocument xmlDocument)
        {
            Writer.xmlDocument = xmlDocument;
            setNavigator();
        }

        private void setNavigator()
        {
            navigator = xmlDocument.CreateNavigator();
            navigator.MoveToChild("Database", networkSchema);
            navigator.MoveToChild("Prescriptions", networkSchema);
        }



        public void AddPrescriptionToXmlDocument(Prescription prescription)
        {

            using (XmlWriter writer = navigator.PrependChild())
            {
                writer.WriteStartElement(networkNamespace, "Prescription", networkSchema);
                writer.WriteAttributeString("id", prescription.Id.ToString());
                writer.WriteAttributeString("doctorId", prescription.PatientId.ToString());
                writer.WriteAttributeString("patientId", prescription.DoctorId.ToString());
                writer.WriteAttributeString("givenAt", prescription.GivenAt);
                writer.WriteAttributeString("expiryDate", prescription.ExpiryDate);
                writer.WriteStartElement(networkNamespace, "Medicines", networkSchema);
                foreach (Medicine medicine in prescription.Medicines)
                {
                    writer.WriteStartElement(networkNamespace, "Medicine", networkSchema);
                    writer.WriteAttributeString("id", medicine.Id.ToString());
                    writer.WriteAttributeString("name", medicine.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            xmlDocument.Save("database.xml");
        }

    }

}

