namespace Patient.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IData : INotifyPropertyChanged
    {
        string PeselText { get; set; }

        int PatientId { get; set; }

        string SelectedProblem { get; set; }

        DateTime SelectedDate { get; set; }

        List<PrescriptionData> PrescriptionList { get; }

        List<VisitData> VisitList { get; }

        List<string> ProblemList { get; }
    }
}
