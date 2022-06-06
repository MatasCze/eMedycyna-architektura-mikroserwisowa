namespace Doctor.AppService.Rest.Application.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void HandleAsync(T command);
    }
}
