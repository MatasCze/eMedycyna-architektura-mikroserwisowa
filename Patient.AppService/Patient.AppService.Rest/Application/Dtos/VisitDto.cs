using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.AppService.Rest.Application.Dtos
{
    public class VisitDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string Problem { get; set; }

        public string Date { get; set; }

        public string Room { get; set; }
    }
}
