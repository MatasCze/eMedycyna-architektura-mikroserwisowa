namespace Doctor.Application.Model
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
                PrescriptionData[] prescriptions = networkClient.GetPrescriptions(this.peselText);

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
        public void AddPrescrption()
        {
            this.AddPrescriptionTask();
        }

        private void AddPrescriptionTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                networkClient.AddPrescription(new PrescriptionData()
                {
                    PatientId = this.PatientId,
                    GivenAt = this.SelectedDate.ToString("dd/MM/yyyy"),
                    ExpiryDate = this.SelectedDate.ToString("dd/MM/yyyy")
                });
            }
            catch (Exception)
            {
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
                int id = networkClient.GetDoctorId(this.PeselText);

                this.PatientId = id;
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
