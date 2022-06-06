namespace Doctors.Rest.Model
{
    public interface IDoctorsService
    {
        public DoctorData[] GetAllDoctors();

        public DoctorSimpleData[] GetDoctor(string lastName);
    }
}
