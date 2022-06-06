using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient.AppService.Rest.Application.Dtos;

namespace PatientApp.Test
{
    [TestClass]
    public class MapperTest1
    {
        VisitDto visitDto = new() { Id = 1, DoctorId = 1, PatientId = 1, Problem = "bol_zeba", Date = "04.09.2021", Room = "16a" };


        [TestMethod]
        public void Test1()
        {

        }
    }
}
