namespace Visits.Tests
{
    using Visits.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Xml;

    [TestClass]
    public class ReaderTests
    {
        private const string databaseXsdFileName = "./../../../Database.xsd";
        private const string databaseXmlFileName = "./../../../Database.xml";

        [TestMethod]
        public void ReadVisits_DatabaseXMLFile_Returns4Visits()
        {
            Reader reader = new Reader();

            XmlDocument databaseXml = reader.ReadDatabaseXml(databaseXmlFileName, databaseXsdFileName);

            int count = reader.ReadVisits(databaseXml).Count;

            Assert.AreEqual(4, count, "Visits count should be {0} and not {1}", 4, count);
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
