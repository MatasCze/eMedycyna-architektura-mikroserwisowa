namespace Doctor.WindowsApplication.Logic.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Model : IData
    {

        public DateTimeOffset SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;
            }
        }
        private DateTimeOffset selectedDate = new DateTimeOffset(new DateTime(2021, 1, 1));

        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                this.patientId = value;
            }
        }
        private int patientId;

        public int DoctorId
        {
            get { return this.doctorId; }
            set
            {
                this.doctorId = value;
            }
        }
        private int doctorId;

        public string PeselText
        {
            get { return this.peselText; }
            set
            {
                this.peselText = value;

                this.RaisePropertyChanged("PeselText");
            }
        }
        private string peselText;

        public List<List<MedicineData>> Medicines
        {
            get
            {
                return new List<List<MedicineData>>()
                {
                    new List<MedicineData>{ new MedicineData() { Id=1, Name="Apap"} }
                };
            }
            set
            {
                this.medicines = value;

                this.RaisePropertyChanged("Medicines");
            }
        }
        private List<List<MedicineData>> medicines;

        public List<PrescriptionData> PrescriptionList
        {
            get { return this.prescriptionList; }
            private set
            {
                this.prescriptionList = value;

                this.RaisePropertyChanged("PrescriptionList");
            }
        }
        private List<PrescriptionData> prescriptionList = new List<PrescriptionData>();

        public List<VisitData> VisitList
        {
            get { return this.visitList; }
            private set
            {
                this.visitList = value;

                this.RaisePropertyChanged("VisitList");
            }
        }
        private List<VisitData> visitList = new List<VisitData>();
    }
}
