namespace Doctor.WindowsApplication.Logic.Controller
{
    using Doctor.WindowsApplication.Logic.Model;
    using Doctor.WindowsApplication.Logic.Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatch)
        {
            if (controller == null)
            {
                IModel newModel = new Model(dispatch) as IModel;

                IController newController = new Controller(dispatch, newModel);

                controller = newController;
            }
            return controller;
        }
    }
}
