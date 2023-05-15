using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.Services.Appointments;
using ClinicManagement.TestTools.Appointments;
using ClinicManagement.TestTools.Doctors;
using ClinicManagement.TestTools.Patients;
using FluentAssertions;
using Xunit;

namespace ClinicManagement.Tests.Unit.Appointments
{
    public class AppointmentUnitTests
    {
        private EFDataContext _context;

        public AppointmentUnitTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
        }
        [Fact]
        public void Set_Constructor_For_Appointment()
        {
            var id = Guid.NewGuid();
            var doctor = DoctorFactory.GenerateSpecialist("reza", "tavakoli");
            _context.Doctors.Add(doctor);
            var patient = PatientFactory.GeneratePatient(id:1, "amir", "fazli");
            _context.Patients.Add(patient);
            _context.SaveChanges();

            var appointment = new Appointment(doctor.Id, patient.Id, new DateTime(2023,05,12,10,05,00), new DateTime(2023, 05, 12, 10, 15, 00));

            appointment.DoctorId.Should().Be(doctor.Id);
            appointment.PatientId.Should().Be(patient.Id);
            appointment.Start.Should().Be(new DateTime(2023, 05, 12, 10, 05, 00));
            appointment.End.Should().Be(new DateTime(2023, 05, 12, 10, 15, 00));
        }
    }
}
