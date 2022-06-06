namespace Doctor.WindowsApplication.View
{
    using Doctor.WindowsApplication.Logic.Controller;
    using Doctor.WindowsApplication.Logic.Model;
    using Doctor.WindowsApplication.Logic.Utilities;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    public sealed partial class NewPrescription : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public NewPrescription()
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
            this.Frame.Navigate(typeof(VisitCalendar), null, new SuppressNavigationTransitionInfo());
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
