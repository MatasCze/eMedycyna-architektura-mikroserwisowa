namespace Patient.Application.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}
