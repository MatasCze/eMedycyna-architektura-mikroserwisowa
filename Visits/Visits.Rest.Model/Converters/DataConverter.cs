namespace Visits.Rest.Model
{
    using Visits.Model;

    public static class DataConverter
    {
        public static VisitData ConvertToVisitData(this Visit visit)
        {
            return new VisitData() { Id = visit.Id, DoctorId = visit.DoctorId, PatientId = visit.PatientId, Problem = visit.Problem, Date = visit.Date, Room = visit.Room };
        }

        public static Visit ConvertToVisit(this VisitData visit)
        {
            return new Visit(visit.Id, visit.DoctorId, visit.PatientId, visit.Problem, visit.Date, visit.Room);
        }
    }

}

