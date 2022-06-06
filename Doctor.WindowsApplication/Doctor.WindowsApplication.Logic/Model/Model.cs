namespace Doctor.WindowsApplication.Logic.Model
{
    using Doctor.WindowsApplication.Logic.Utilities;
    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
