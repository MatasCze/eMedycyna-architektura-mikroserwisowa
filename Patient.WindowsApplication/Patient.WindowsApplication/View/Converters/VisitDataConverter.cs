namespace Patient.WindowsApplication.View
{
    using Patient.WindowsApplication.Model;
    using System;
    using Windows.UI.Xaml.Data;

    public class VisitDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            VisitData visitData = (VisitData)value;

            return String.Format("Lekarz: {0} {1} | Data: {2} | Gabinet: {3} | Problem: {4}",
                visitData.DoctorFirstName, visitData.DoctorLastName, visitData.Date, visitData.Room, visitData.Problem);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }


    }
}