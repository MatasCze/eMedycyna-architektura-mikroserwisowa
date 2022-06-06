namespace Patient.WindowsApplication.Model
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

        public int GetPatientId(string pesel)
        {
            string callUri = String.Format("GetPatientId?pesel={0}", pesel);

            int id = this.serviceClient.CallWebService<int>(HttpMethod.Get, callUri);

            return id;
        }

        public PrescriptionData[] GetPrescriptions(int patientId)
        {
            string callUri = String.Format("GetAllPrescriptions?patientId={0}", patientId);

            PrescriptionData[] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>(HttpMethod.Get, callUri);

            return prescriptions;
        }

        public VisitData[] GetVisits(int patientId)
        {
            string callUri = String.Format("GetAllVisits?patientId={0}", patientId);

            VisitData[] visits = this.serviceClient.CallWebService<VisitData[]>(HttpMethod.Get, callUri);

            return visits;
        }

        public void AddVisit(VisitData visit)
        {
            var callUri = "AddVisit";

            var json = JsonConvert.SerializeObject(new VisitData
            {
                PatientId = visit.PatientId,
                Date = visit.Date,
                Problem = visit.Problem
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            this.serviceClient.PostWebService(callUri, data);
        }
    }
}
