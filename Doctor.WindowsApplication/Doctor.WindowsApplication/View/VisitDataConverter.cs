namespace Doctor.WindowsApplication.View
{
    using Doctor.WindowsApplication.Logic.Model;
    using System;
    using Windows.UI.Xaml.Data;
    public class VisitDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            VisitData visitData = (VisitData)value;

            return String.Format("Data: {0} | Gabinet: {1} | Problem: {2}",
                visitData.Date, visitData.Room, visitData.Problem);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }


    }
}
