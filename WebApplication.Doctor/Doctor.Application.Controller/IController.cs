namespace Doctor.Application.Controller
{
    using Doctor.Application.Model;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        Task SearchVisitsAsync();

        Task LoginAsync();

        Task LogoutAsync();

        Task AddPresctiptionAsync();

        Task SearchPatientAsync();
    }
}
