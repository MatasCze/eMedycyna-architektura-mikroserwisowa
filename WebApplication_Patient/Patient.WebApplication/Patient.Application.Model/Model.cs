namespace Patient.Application.Model
{
    using Patient.Application.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
