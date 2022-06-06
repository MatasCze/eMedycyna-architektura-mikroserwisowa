namespace Doctors.Rest.Model
{
    using System.Collections.Generic;

    public class DoctorSimpleData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<SpecializationData> Specializations { get; set; } = new List<SpecializationData>();

    }
}