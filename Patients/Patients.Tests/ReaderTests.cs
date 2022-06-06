namespace Patients.Tests
{
    using System;
    using System.Xml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patients.Logic;

    [TestClass]
    public class ReaderTests
    {
        private const string databaseXsdFileName = "./../../../Database.xsd";
        private const string databaseXmlFileName = "./../../../Database.xml";

        [TestMethod]
        public void ReadPatients_DatabaseXmlFile_Returns6Patients()
        {
            Reader reader = new Reader();

            XmlDocument databaseXml = reader.ReadDatabaseXml(databaseXmlFileName, databaseXsdFileName);

            int count = reader.ReadPatients(databaseXml).Count;

            Assert.AreEqual(6, count, "Patients count should be {0} and not {1}", 6, count);
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
