namespace Patient.WindowsApplication.Controller
{
    using System.Windows.Input;

    public partial class Controller : IController
    {
        public ICommand RefreshPrescriptionsCommand { get; private set; }

        public ICommand RefreshVisitsCommand { get; private set; }

        public ICommand LoginCommand { get; private set; }

        public ICommand LogoutCommand { get; private set; }

        public ICommand AddVisitCommand { get; private set; }

        private void RefreshPrescriptions()
        {
            this.Model.LoadPrescriptionList();
        }

        private void RefreshVisits()
        {
            this.Model.LoadVisitList();
        }

        private void Login()
        {
            this.Model.Login();
        }

        private void Logout()
        {
            this.Model.Logout();
        }

        private void AddVisit()
        {
            this.Model.AddVisit();
        }
    }
}
