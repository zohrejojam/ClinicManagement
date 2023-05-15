using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.TestTools.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.TestTools.WeeklySchedules
{
    public class WeeklyScheduleBuilder
    {
        private static Specialist doctor = DoctorFactory.GenerateSpecialist("reza", "tavakoli");
        private WeeklySchedule weeklySchedule = new WeeklySchedule
        (1, DateTime.Now.AddHours(1), DateTime.Now.AddHours(5), doctor.Id);


        public WeeklyScheduleBuilder WithId(int id)
        {
            weeklySchedule.Id = id;
            return this;
        }
        public WeeklyScheduleBuilder WithDoctor(Guid doctorId)
        {
            weeklySchedule.DoctorId = doctorId;
            return this;
        }

        public WeeklyScheduleBuilder WithStartDate(DateTime startDate)
        {
            weeklySchedule.StartTime = startDate;
            return this;
        }

        public WeeklyScheduleBuilder WithEndDate(DateTime endDate)
        {
            weeklySchedule.EndTime = endDate;
            return this;
        }

        public WeeklySchedule Build()
        {
            return weeklySchedule;
        }
    }
}
