namespace Patient.WindowsApplication.Controller
{
    using Patient.WindowsApplication.Model;
    using System.ComponentModel;
    using System.Windows.Input;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ICommand RefreshPrescriptionsCommand { get; }

        ICommand RefreshVisitsCommand { get; }

        ICommand AddVisitCommand { get; }

        ICommand LoginCommand { get; }

        ICommand LogoutCommand { get; }
    }
}
