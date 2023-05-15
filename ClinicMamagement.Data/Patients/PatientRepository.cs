using ClinicManagement.Core;
using ClinicManagement.Services.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicMamagement.Data.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private EFDataContext _context;

        public PatientRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<bool> HasOverlapAppointmentForPatient(int patientId , DateTime start , DateTime end,string DurationVisit)
        {
            var duration = int.Parse(DurationVisit);
            var hasOverlap = await _context.Patients.AnyAsync(_ => _.Id == patientId &&
                                                     _.Appointments.Any(p=>(p.Start<=start && p.End>=start) || (p.Start <= end && p.End >= end)));
            return hasOverlap;
        }
    }
}
