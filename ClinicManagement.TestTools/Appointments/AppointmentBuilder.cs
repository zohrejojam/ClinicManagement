using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.TestTools.Appointments
{
    public class AppointmentBuilder
    {
        private static Guid doctorid = Guid.NewGuid();
        private static int patientId = 1;
        private Appointment appointment = new Appointment(doctorid, patientId,
                new DateTime(2023, 05, 12, 10, 05, 00), new DateTime(2023, 05, 12, 10, 15, 00));

        public AppointmentBuilder WithDoctor(Guid doctorId)
        {
            appointment.DoctorId = doctorId;
            return this;
        }

        public AppointmentBuilder WithPatient(int patientId)
        {
            appointment.PatientId = patientId;
            return this;
        }

        public AppointmentBuilder WithStartDate(DateTime startDate)
        {
            appointment.Start = startDate;
            return this;
        }

        public AppointmentBuilder WithEndDate(DateTime endDate)
        {
            appointment.End = endDate;
            return this;
        }
        public Appointment Build(EFDataContext context)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
            return appointment;
        }
    }
}
