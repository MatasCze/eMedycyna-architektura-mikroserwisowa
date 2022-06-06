namespace Doctor.Application.Controller
{
    using System.Threading.Tasks;

    public partial class Controller : IController
    {

        #region Patient

        public async Task SearchPatientAsync()
        {
            await Task.Run(() => this.SearchPatient());
        }

        private void SearchPatient()
        {
            this.Model.LoadPatient();
        }

        #endregion

        #region Prescription
        public async Task AddPrescriptionAsync()
        {
            await Task.Run(() => this.AddPrescription());
        }

        private void AddPrescription()
        {
            this.Model.AddPrescription();
        }

        #endregion

        #region Auth

        public async Task LoginAsync()
        {
            await Task.Run(() => this.Login());
        }

        public async Task LogoutAsync()
        {
            await Task.Run(() => this.Logout());
        }

        private void Login()
        {
            this.Model.Login();
        }

        private void Logout()
        {
            this.Model.Logout();
        }

        #endregion


        #region Visits

        public async Task SearchVisitsAsync()
        {
            await Task.Run(() => this.SearchVisits());
        }

        private void SearchVisits()
        {
            this.Model.LoadVisitList();
        }

        #endregion

    }
}
