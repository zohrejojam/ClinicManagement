using ClinicManagement.Core;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.Services.Doctors;
using System;
using System.Threading.Tasks;

namespace ClinicMamagement.Data.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private EFDataContext _context;

        public DoctorRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctor(Guid doctorId)
        {
            return await _context.Doctors.FindAsync(doctorId);
        }

    }
}
