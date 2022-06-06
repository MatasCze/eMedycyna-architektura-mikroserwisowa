namespace Visits.Logic
{
    using System.Xml;
    using System.Xml.XPath;
    using Visits.Model;

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
            navigator.MoveToChild("Visits", networkSchema);
        }

        public void AddVisitToXmlDocument(Visit visit)
        {

            using (XmlWriter writer = navigator.PrependChild())
            {
                writer.WriteStartElement(networkNamespace, "Visit", networkSchema);
                writer.WriteAttributeString("id", visit.Id.ToString());
                writer.WriteAttributeString("doctorId", visit.DoctorId.ToString());
                writer.WriteAttributeString("patientId", visit.PatientId.ToString());
                writer.WriteAttributeString("problem", visit.Problem);
                writer.WriteAttributeString("date", visit.Date);
                writer.WriteAttributeString("room", visit.Room);
                writer.WriteEndElement();
            }
            xmlDocument.Save("database.xml");
        }

    }
}
