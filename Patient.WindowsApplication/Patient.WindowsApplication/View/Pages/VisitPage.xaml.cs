namespace Patient.WindowsApplication.View
{
    using Patient.WindowsApplication.Controller;
    using Patient.WindowsApplication.Model;
    using Patient.WindowsApplication.Utilities;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class VisitPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public VisitPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;
        }

        private void Btn_GoToPrescriptionPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PrescriptionPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Btn_GoToLoginPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Btn_GoToVisitCalendarPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VisitCalendarPage), null, new SuppressNavigationTransitionInfo());
        }
    }
}
