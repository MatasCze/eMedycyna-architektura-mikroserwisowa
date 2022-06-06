namespace Prescriptions.Test
{
    using Prescriptions.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Xml;

    [TestClass]
    public class ReaderTests
    {
        private const string databaseXsdFileName = "./../../../Database.xsd";
        private const string databaseXmlFileName = "./../../../Database.xml";

        [TestMethod]
        public void ReadDoctors_DatabaseXmlFile_Returns7Prescriptions()
        {
            Reader reader = new Reader();

            XmlDocument databaseXml = reader.ReadDatabaseXml(databaseXmlFileName, databaseXsdFileName);

            int count = reader.ReadPrescriptions(databaseXml).Count;

            Assert.AreEqual(7, count, "Prescriptions count should be {0} and not {1}", 7, count);
        }

        [DataTestMethod]
        [DataRow(databaseXsdFileName, "")]
        [DataRow("", databaseXmlFileName)]
        public void ReadDatabaseXml_EmptyFileName_ThrowsArgumentException(string xsdFileName, string xmlFileName)
        {
            Reader reader = new Reader();

            Action action = () => reader.ReadDatabaseXml(xsdFileName, xmlFileName);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }
    }
}
