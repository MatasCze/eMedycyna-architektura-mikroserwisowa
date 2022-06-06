namespace Doctors.Rest.Model
{
    using Doctors.Model;
    using System.Collections.Generic;

    public static class DataConverter
    {
        public static IList<SpecializationData> ConvertToSpecializationData(this IList<Specialization> specializations)
        {
            IList<SpecializationData> specializationDataList = new List<SpecializationData>();
            foreach (Specialization specialization in specializations)
            {
                specializationDataList.Add(new SpecializationData() { Id = specialization.Id, Name = specialization.Name });
            }
            return specializationDataList;
        }

        public static DoctorData ConvertToDoctorData(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorData() { Id = doctor.Id, FirstName = doctor.FirstName, LastName = doctor.LastName, Pesel = doctor.Pesel, Specializations = ConvertToSpecializationData(doctor.Specializations) };
        }

        public static DoctorSimpleData ConvertToDoctorSimpleData(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorSimpleData() {FirstName = doctor.FirstName, LastName = doctor.LastName, Specializations = ConvertToSpecializationData(doctor.Specializations) };
        }
    }
}
