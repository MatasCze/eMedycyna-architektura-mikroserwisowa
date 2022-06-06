namespace Patient.WindowsApplication.Model
{
    using Patient.WindowsApplication.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
