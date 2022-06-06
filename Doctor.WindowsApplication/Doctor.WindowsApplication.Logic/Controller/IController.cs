using Doctor.WindowsApplication.Logic.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace Doctor.WindowsApplication.Logic.Controller
{
    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ICommand RefreshPrescriptionsCommand { get; }

        ICommand RefreshVisitsCommand { get; }

        ICommand PatientCommand { get; }

        ICommand AddVisitCommand { get; }

        ICommand LoginCommand { get; }

        ICommand LogoutCommand { get; }
    }
}