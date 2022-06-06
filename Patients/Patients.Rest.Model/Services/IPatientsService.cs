namespace Patients.Rest.Model.Services
{
    using Patients.Rest.Model.Model;

    public interface IPatientsService
    {
        public PatientData[] GetAllPatients();

        public PatientData GetPatientByPesel(string pesel);
    }
}
