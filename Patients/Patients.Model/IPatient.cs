namespace Patients.Model
{
    public interface IPatient
    {
        public Patient[] GetAllPatients();

        public Patient GetPatientByPesel(string pesel);
    }
}
