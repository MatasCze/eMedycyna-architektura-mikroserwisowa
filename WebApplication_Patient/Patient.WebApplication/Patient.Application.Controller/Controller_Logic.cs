namespace Patient.Application.Controller
{
    using System.Threading.Tasks;

    public partial class Controller : IController
    {

        #region Prescriptions

        public async Task SearchPrescriptionsAsync()
        {
            await Task.Run(() => this.SearchPrescriptions());
        }

        private void SearchPrescriptions()
        {
            this.Model.LoadPrescriptionList();
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

        public async Task AddVisitAsync()
        {
            await Task.Run(() => this.AddVisit());
        }

        private void SearchVisits()
        {
            this.Model.LoadVisitList();
        }

        private void AddVisit()
        {
            this.Model.AddVisit();
        }

        #endregion

    }
}
