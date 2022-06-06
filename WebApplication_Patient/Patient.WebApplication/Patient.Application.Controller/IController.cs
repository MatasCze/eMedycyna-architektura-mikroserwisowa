namespace Patient.Application.Controller
{
    using Patient.Application.Model;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        Task SearchPrescriptionsAsync();

        Task LoginAsync();

        Task LogoutAsync();

        Task AddVisitAsync();

        Task SearchVisitsAsync();
    }
}
