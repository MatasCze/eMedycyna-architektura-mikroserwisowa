namespace Patient.Application.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Model : IData
    {

        public DateTime SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;
            }
        }
        private DateTime selectedDate = new DateTime();

        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                this.patientId = value;
            }
        }
        private int patientId;


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

        public string SelectedProblem
        {
            get { return this.selectedProblem; }
            set
            {
                this.selectedProblem = value;
            }
        }
        private string selectedProblem;

        public List<string> ProblemList
        {
            get
            {
                return new List<string>()
                {
                    "Neurologia", "Kardiologia", "Okulistyka", "Ortopedia", "Pediatria", "Alergologia"
                };
            }
        }

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
