namespace Patient.Application.Controller
{
    using Patient.Application.Model;
    using Patient.Application.Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;
        }
    }
}
