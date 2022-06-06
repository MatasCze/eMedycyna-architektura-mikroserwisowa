namespace Patients.Model
{
    public class Patient
    {
        public int Id { get; private set; }

        public string Pesel { get; private set; }

        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public Patient(int id, string pesel, string lastName, string firstName)
        {
            Id = id;
            Pesel = pesel;
            LastName = lastName ;
            FirstName = firstName;
        }
    }
}
