namespace ClinicManagement.Services.Patients
{
    public interface IPatientRepository
    {
        Task<bool> HasOverlapAppointmentForPatient(int patientId, DateTime start, DateTime end,string durationVisit);
     }
}
