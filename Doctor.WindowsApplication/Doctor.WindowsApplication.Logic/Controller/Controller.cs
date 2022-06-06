namespace Doctor.WindowsApplication.Logic.Controller
{
    using Doctor.WindowsApplication.Logic.Model;
    using Doctor.WindowsApplication.Logic.Utilities;

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
        }
    }
}
