using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;

namespace ClinicManagement.Services.Appointments
{
    public interface IAppointmentService
    {
        Task SetAppointment(Doctor doctor, Patient patient, DateTime Start, DateTime End);

        Task SetEarliestAppointment(Doctor doctor, Patient patient);
    }
}
