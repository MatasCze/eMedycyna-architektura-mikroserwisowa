namespace Patient.WindowsApplication.Model
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
                PrescriptionData[] prescriptions = networkClient.GetPrescriptions(this.PatientId);

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
                VisitData[] Visits = networkClient.GetVisits(this.PatientId);

                this.VisitList = Visits.ToList();
            }
            catch (Exception)
            {
            }
        }
        public void AddVisit()
        {
            Task.Run(() => this.AddVisitTask());
        }

        private void AddVisitTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();
            if (this.SelectedProblem != null && this.SelectedDate != null && patientId != 0)
                try
                {
                    networkClient.AddVisit(new VisitData()
                    {
                        PatientId = this.PatientId,
                        Problem = this.SelectedProblem,
                        Date = this.SelectedDate.DateTime.ToShortDateString()
                    });
                }
                catch (Exception)
                {
                }

        }

        public void Logout()
        {
            this.PrescriptionList.Clear();

            this.PatientId = 0;
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
                int id = networkClient.GetPatientId(this.PeselText);

                this.PatientId = id;

                PrescriptionData[] prescriptions = networkClient.GetPrescriptions(this.PatientId);

                this.PrescriptionList = prescriptions.ToList();
            }
            catch (Exception)
            {
            }
        }
    }
}
