namespace Doctors.Model
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Pesel { get; private set; }

        public IList<Specialization> Specializations { get; private set; } = new List<Specialization>();


        public Doctor(int id, string firstName, string lastName, string pesel)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }

        public Doctor(int id, string firstName, string lastName, string pesel, IList<Specialization> specializations) : this(id, firstName, lastName, pesel)
        {
            Specializations = specializations;
        }

        public void AddSpecialization(Specialization specialization)
        {
            Specializations.Add(specialization);
        }

        public void AddSpecializations(IEnumerable<Specialization> specializations)
        {
            foreach (var specialization in specializations)
                Specializations.Add(specialization);
        }
    }
}
