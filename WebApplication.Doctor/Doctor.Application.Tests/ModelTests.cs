namespace Doctor.Application.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;

    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void LoadPrescriptionList_ReadsFromPrescriptionList_ThereIsOnePrescription()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            model.LoadPrescriptionList();

            int expectedCount = 1;

            int actualCount = model.PrescriptionList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount);
        }


        [TestMethod]
        public void LoadVisitList_ReadsFromVisitList_ThereIsTwoVisit()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            model.LoadVisitList();

            int expectedCount = 2;

            int actualCount = model.VisitList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Visit count should be {0} and not {1}", expectedCount, actualCount);
        }
    }
}
