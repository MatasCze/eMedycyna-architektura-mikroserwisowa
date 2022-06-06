namespace Doctors.Model
{
    public interface IDoctors
    {
        public Doctor[] GetAllDoctors();

        public Doctor[] GetDoctor(string lastName);

        public Doctor GetDoctor(int doctorId);

        public Doctor GetDoctorBySpecialization(string specialization);
    }
}
