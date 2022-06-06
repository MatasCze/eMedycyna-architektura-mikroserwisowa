namespace Doctor.WindowsApplication.Logic.Model
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public partial class Model : IOperations
    {
        public void LoadPrescriptionList()
        {
            Task.Run(() => this.LoadPrescriptionsTask());
        }

        private void LoadPrescriptionsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                PrescriptionData[] prescriptions = networkClient.GetPrescriptions(this.peselText);

                this.PrescriptionList = prescriptions.ToList();
            }
            catch (Exception)
            {
            }
        }

        public void LoadVisitList()
        {
            Task.Run(() => this.LoadVisitsTask());
        }

        private void LoadVisitsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                VisitData[] Visits = networkClient.GetVisits(this.DoctorId);

                this.VisitList = Visits.ToList();
            }
            catch (Exception)
            {
            }
        }

        public void Logout()
        {
            this.PrescriptionList.Clear();

            this.DoctorId = 0;

            this.PeselText = "";
        }

        public void Login()
        {
            Task.Run(() => this.LoginTask());
        }

        private void LoginTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                VisitData[] Visits = networkClient.GetVisits(this.DoctorId);

                this.VisitList = Visits.ToList();
            }
            catch (Exception)
            {
            }
        }
    }
}
