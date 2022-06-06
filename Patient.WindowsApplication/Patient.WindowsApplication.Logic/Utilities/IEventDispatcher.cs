namespace Patient.WindowsApplication.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}
