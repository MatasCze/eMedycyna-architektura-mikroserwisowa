namespace Doctor.WindowsApplication.View
{
    using Doctor.WindowsApplication.Logic.Controller;
    using Doctor.WindowsApplication.Logic.Model;
    using Doctor.WindowsApplication.Logic.Utilities;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    public sealed partial class VisitCalendar : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public VisitCalendar()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.Controller.Model.LoadVisitList();

            this.DataContext = this.Controller;
        }

        private void Btn_GoToNewPrescription_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewPrescription), null, new SuppressNavigationTransitionInfo());
        }

        private void Btn_GoToPrescriptionPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PrescriptionPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Btn_GoToLoginPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null, new SuppressNavigationTransitionInfo());
        }

    }
}
