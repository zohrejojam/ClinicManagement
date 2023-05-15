using ClinicManagement.Core.Models;

namespace ClinicManagement.Services.Appointments
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
    }
}
