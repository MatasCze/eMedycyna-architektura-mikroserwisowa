namespace Patient.AppService.Rest.Application.Mapper
{
    using Patient.AppService.Rest.Application.Commands;
    using Patient.AppService.Rest.Application.Dtos;

    public static class Mapper
    {
        public static AddVisitCommand Map(this VisitDto visit)
        {
            if (visit == null)
                return null;

            return new AddVisitCommand
            {
                Id = visit.Id,
                PatientId = visit.PatientId,
                DoctorId = visit.DoctorId,
                Problem = visit.Problem,
                Date = visit.Date,
                Room = visit.Room
            };
        }
    }
}
