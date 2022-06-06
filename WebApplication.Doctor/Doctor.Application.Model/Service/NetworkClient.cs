namespace Doctor.Application.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public int GetDoctorId(string pesel)
        {
            string callUri = String.Format("GetPatientId?pesel={0}", pesel);

            int id = this.serviceClient.CallWebService<int>(HttpMethod.Get, callUri);

            return id;
        }

        public PrescriptionData[] GetPrescriptions(string peselText)
        {
            string callUri = String.Format("GetAllPrescriptions?pesel={0}", peselText);

            PrescriptionData[] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>(HttpMethod.Get, callUri);

            return prescriptions;
        }

        public VisitData[] GetVisits(int doctorId)
        {
            string callUri = String.Format("GetVisits?doctorId={0}", doctorId);

            VisitData[] visits = this.serviceClient.CallWebService<VisitData[]>(HttpMethod.Get, callUri);

            return visits;
        }


        public void AddPrescription(PrescriptionData prescription)
        {
            var callUri = "AddPrescription";

            var json = JsonConvert.SerializeObject(new PrescriptionData
            {
                Id = prescription.Id,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId,
                GivenAt = DateTime.Now.ToString(),
                ExpiryDate = prescription.ExpiryDate,
                Medicines = prescription.Medicines
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            this.serviceClient.PostWebService(callUri, data);
        }
    }
}
