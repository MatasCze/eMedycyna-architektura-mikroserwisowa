namespace Doctor.WindowsApplication.Logic.Model
{
    using Doctor.WindowsApplication.Logic.Utilities;
    using System;
    using System.Diagnostics;
    using System.Net.Http;
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

        public PrescriptionData[] GetPrescriptions(string peselText)
        {
            string callUri = String.Format("GetPrescriptions?pesel={0}", peselText);

            PrescriptionData[] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>(HttpMethod.Get, callUri);

            return prescriptions;
        }

        public VisitData[] GetVisits(int doctorId)
        {
            string callUri = String.Format("GetVisits?doctorId={0}", doctorId);

            VisitData[] visits = this.serviceClient.CallWebService<VisitData[]>(HttpMethod.Get, callUri);

            return visits;
        }
    }
}
