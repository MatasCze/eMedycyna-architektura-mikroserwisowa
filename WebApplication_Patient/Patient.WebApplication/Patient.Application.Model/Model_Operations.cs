namespace Patient.Application.Model
{
    using System;
    using System.Linq;

    public partial class Model : IOperations
    {

        #region Prescriptions

        public void LoadPrescriptionList()
        {
            this.LoadPrescriptionsTask();
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

        #endregion


        #region Visits

        public void LoadVisitList()
        {
            this.LoadVisitsTask();
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
            this.AddVisitTask();
        }

        private void AddVisitTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            if (this.SelectedProblem != null && this.SelectedDate != new DateTime() && patientId != 0)
            {
                try
                {
                    networkClient.AddVisit(new VisitData()
                    {
                        PatientId = this.PatientId,
                        Problem = this.SelectedProblem,
                        Date = this.SelectedDate.ToString("dd/MM/yyyy")
                    });
                }
                catch (Exception)
                {
                }
            }

        }

        #endregion


        #region Auth

        public void Logout()
        {
            this.VisitList.Clear();

            this.PrescriptionList.Clear();

            this.PatientId = 0;
        }

        public void Login()
        {
            this.LoginTask();
        }

        private void LoginTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                int id = networkClient.GetPatientId(this.PeselText);

                this.PatientId = id;
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
