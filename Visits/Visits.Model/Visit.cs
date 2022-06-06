namespace Visits.Model
{
    public class Visit
    {
        public int Id { get; private set; }

        public int DoctorId { get; private set; }

        public int PatientId { get; private set; }

        public string Problem { get; private set; }

        public string Date { get; private set; }

        public string Room { get; private set; }

        public Visit(int id, int doctorId, int patientId, string problem, string date, string room)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            Problem = problem;
            Date = date;
            Room = room;
        }
    }
}
