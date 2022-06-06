namespace Doctor.Application.Controller
{
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;
    using Microsoft.EntityFrameworkCore.Metadata;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;
        }
    }
}
