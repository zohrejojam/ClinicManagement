using ClinicManagement.Core.Models.Doctors;

namespace ClinicManagement.Services.Doctors
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctor(Guid doctorId);
    }
}
