namespace Patients.Rest.Model
{
    using Patients.Model;
    using Patients.Rest.Model.Model;

    public static class DataConverter
    {
        public static PatientData ConvertToPatientData(this Patient patient)
        {
            if (patient != null)
                return new PatientData() { Id = patient.Id, Pesel = patient.Pesel, LastName = patient.LastName, FirstName = patient.FirstName };
            else
                return new PatientData();
        }
    }
}
