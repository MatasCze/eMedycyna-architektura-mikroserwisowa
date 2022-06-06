namespace Doctors.Rest.Model
{
    using System.Collections.Generic;

    public class DoctorData
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }

        public IList<SpecializationData> Specializations { get; set; } = new List<SpecializationData>();

    }
}
