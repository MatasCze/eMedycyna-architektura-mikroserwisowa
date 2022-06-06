namespace Patient.Application.Model
{
    using System;

    public class VisitAddHelperData
    {
        public int PatientId { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorLastName { get; set; }

        public string Problem { get; set; }

        public DateTime Date { get; set; }

        public string Room { get; set; }
    }
}
