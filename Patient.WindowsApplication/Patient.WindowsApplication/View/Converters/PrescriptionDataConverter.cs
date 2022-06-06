namespace Patient.WindowsApplication.View
{
    using Patient.WindowsApplication.Model;
    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Data;

    public class PrescriptionDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            PrescriptionData prescriptionData = (PrescriptionData)value;

            return String.Format("Data wydania: {0} | Data ważności: {1} | \nLeki: {2}",
                prescriptionData.GivenAt, prescriptionData.ExpiryDate, convertMedicineDataToString(prescriptionData.Medicines));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private string convertMedicineDataToString(IList<MedicineData> medicines)
        {
            string result = "";

            foreach(MedicineData medicine in medicines)
            {
                result += medicine.Name + ", ";
            }

            return result;
        }

    }
}
