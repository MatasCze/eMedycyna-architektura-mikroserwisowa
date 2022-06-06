namespace Doctor.Application.Model
{
    using Doctor.Application.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
