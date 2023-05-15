using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Services.Appointments;

namespace ClinicMamagement.Data.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private EFDataContext _context;

        public AppointmentRepository(EFDataContext context)
        {
            _context = context;
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}
