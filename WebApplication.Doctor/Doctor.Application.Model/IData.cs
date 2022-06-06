namespace Doctor.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IData : INotifyPropertyChanged
    {
        string PeselText { get; set; }

        int PatientId { get; set; }

        int DoctorId { get; set; }

        DateTime SelectedDate { get; set; }

        List<PrescriptionData> PrescriptionList { get; }

        List<VisitData> VisitList { get; }

    }
}
