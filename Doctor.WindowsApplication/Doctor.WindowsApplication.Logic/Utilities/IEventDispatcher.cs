namespace Doctor.WindowsApplication.Logic.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}
