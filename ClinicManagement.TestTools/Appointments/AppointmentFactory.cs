using ClinicMamagement.Data.Appointments;
using ClinicMamagement.Data.Patients;
using ClinicManagement.Core;
using ClinicManagement.Services.Appointments;

namespace ClinicManagement.TestTools.Appointments
{
    public static class AppointmentFactory
    {
        public static IAppointmentService CreateService(EFDataContext context)
        {
            var repository = new AppointmentRepository(context);
            var patientRepository = new PatientRepository(context);
            return new AppointmentService(repository, patientRepository);
        }
    }
}
