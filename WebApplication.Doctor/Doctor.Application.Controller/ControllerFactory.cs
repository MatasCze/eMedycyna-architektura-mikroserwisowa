﻿namespace Doctor.Application.Controller
{
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;
    using Microsoft.EntityFrameworkCore.Metadata;

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
