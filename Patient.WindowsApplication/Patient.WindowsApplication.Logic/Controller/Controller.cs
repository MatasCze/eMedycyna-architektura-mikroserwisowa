namespace Patient.WindowsApplication.Controller
{
    using Patient.WindowsApplication.Model;
    using Patient.WindowsApplication.Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.RefreshPrescriptionsCommand = new ControllerCommand(this.RefreshPrescriptions);

            this.LoginCommand = new ControllerCommand(this.Login);

            this.LogoutCommand = new ControllerCommand(this.Logout);

            this.RefreshVisitsCommand = new ControllerCommand(this.RefreshVisits);

            this.AddVisitCommand = new ControllerCommand(this.AddVisit);
        }
    }
}
