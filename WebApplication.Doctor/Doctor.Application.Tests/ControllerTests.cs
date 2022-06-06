namespace Doctor.Application.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Doctor.Application.Controller;
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;
    using System.Threading.Tasks;

    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public async Task SearchPrescriptionsAsync_ReadsFromModel_ThereIsOnePrescription()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            await controller.SearchPrescriptionsAsync();

            int expectedCount = 1;

            int actualCount = model.PrescriptionList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount);
        }

        [TestMethod]
        public async Task SearchVisitsAsync_ReadsFromModel_ThereIsTwoVisits()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            IController controller = new Controller(new EmptyEventDispatcher(), model);

            await controller.SearchVisitsAsync();

            int expectedCount = 2;

            int actualCount = model.VisitList.Count;

            Assert.AreEqual(expectedCount, actualCount, "Visit count should be {0} and not {1}", expectedCount, actualCount);
        }
    }
}
