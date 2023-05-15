using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.Services.Appointments.Exceptions;
using ClinicManagement.Services.Patients;

namespace ClinicManagement.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository repository, IPatientRepository patientRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
        }

        public async Task SetAppointment(Doctor doctor, Patient patient, DateTime start, DateTime end)
        {
            var isDoctorPresent = doctor.WeeklySchedules.Any(s => s.StartTime <= start && s.EndTime >= end);
            if (!isDoctorPresent)
                throw new DoctorIsNotPresentAtThisTime();
            var appointment = new Appointment(doctor.Id, patient.Id, start, end);
            var hasOverlapAppointment = await _patientRepository.HasOverlapAppointmentForPatient(patient.Id, start, end,doctor.DurationVisit);
            if (hasOverlapAppointment)
                throw new ThisAppointmentHasOverlap();
            _repository.AddAppointment(appointment);

            //Send sms or email to doctor and patient
        }

        public async Task SetEarliestAppointment(Doctor doctor, Patient patient)
        {
            var doctorSchedules = doctor.WeeklySchedules.OrderBy(_ => _.StartTime)
                .Where(_ => _.StartTime >= DateTime.Now)
                .ToList();
            var result = new WeeklySchedule();
            foreach (var timeForVisit in doctorSchedules)
            {
                var hasPatientOverlap = await _patientRepository.HasOverlapAppointmentForPatient(patient.Id, timeForVisit.StartTime, timeForVisit.EndTime,doctor.DurationVisit);
                if (!hasPatientOverlap)
                {
                    result = timeForVisit;
                    break;
                }
            }
            if (result.DoctorId == Guid.Empty)
                throw new Exception("Currently, it is not possible to make an appointment");
            var duration = int.Parse(doctor.DurationVisit);
            var appointment = new Appointment(doctor.Id, patient.Id, result.StartTime, result.StartTime.AddMinutes(duration));
            _repository.AddAppointment(appointment);
        }

        public void ChangeAppointment(Guid appointmentId, DateTime newStart, DateTime newEnd)
        {
            //Change the appointment
            //Send sms or email to doctor and patient
        }
    }
}
