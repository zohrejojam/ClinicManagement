using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.Services.Appointments;
using ClinicManagement.Services.Appointments.Exceptions;
using ClinicManagement.Tests.Integration.Infrastructure;
using ClinicManagement.TestTools.Appointments;
using ClinicManagement.TestTools.Doctors;
using ClinicManagement.TestTools.Patients;
using ClinicManagement.TestTools.WeeklySchedules;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ClinicManagement.Tests.Integration.Appointments
{
    public class SetAppointmentWithOverlap : EFDataContextDatabaseFixture
    {
        private EFDataContext _context;
        private EFDataContext _secondContext;
        private IAppointmentService sut;
        private Doctor doctor;
        private Patient patient;
        Func<Task> expected;

        public SetAppointmentWithOverlap()
        {
            //این خط جهت تست با دیتابیس اینمموری، کامنت شود
            //EFDataContextDatabaseFixture همچنین از این کلاس ارث بری نشود
            _context = CreateDataContext();
            _secondContext = CreateDataContext();

            //این دوخط جهت تست با دیتابیس اینمموری آنکامنت شود
            //var db = new EFInMemoryDatabase();
            //_context = db.CreateDataContext<EFDataContext>();
        }

        //یک دکتر متخصص به نام رضا توکلی در روز2023/05/13
        //از ساعت 9 الی 17 در درمانگاه حضور دارد
        //دو قرار ملاقات در تاریخ 2023/05/13  از ساعت 10 الی 10:15
        // و تاریخ 2023/05/13  از ساعت 11 الی 11:30
        //برای بیمار با نام زهره جوجم برای دکتر توکلی تنظیم شده است
        private  void Given()
        {
            sut = AppointmentFactory.CreateService(_context);
            doctor = DoctorFactory.GenerateSpecialist("reza", "tavakoli");
            var weeklyScedules = new WeeklyScheduleBuilder().WithId(1)
                .WithStartDate(new DateTime(2023, 05, 13, 9, 00, 00))
                .WithEndDate(new DateTime(2023, 05, 13, 17, 00, 00))
                .WithDoctor(doctor.Id)
                .Build();
            doctor.WeeklySchedules.Add(weeklyScedules);
            _secondContext.Doctors.Add(doctor);

            patient = PatientFactory.GeneratePatient(id: 1, "zohre", "jojam");
            _secondContext.Set<Patient>().Add(patient);

            _secondContext.SaveChanges();
            var firstAppointment = new AppointmentBuilder()
                .WithPatient(patient.Id)
                .WithDoctor(doctor.Id)
                .WithStartDate(new DateTime(2023, 05, 13, 10, 00, 00))
                .WithEndDate(new DateTime(2023, 05, 13, 10, 15, 00))
                .Build(_secondContext);

            var secondAppointment = new AppointmentBuilder()
                .WithPatient(patient.Id)
                .WithDoctor(doctor.Id)
                .WithStartDate(new DateTime(2023, 05, 13, 11, 00, 00))
                .WithEndDate(new DateTime(2023, 05, 13, 11, 30, 00))
                .Build(_secondContext);

        }

        // زمانی که یک قرار ملاقات با دکتر توکلی برای بیمار با نام زهره جوجم 
        // در تاریخ 2023/05/13  از ساعت 10 الی 10:15 ثبت میشود
        private void When()
        {
            expected  = async () => await sut.SetAppointment(doctor, patient, new DateTime(2023, 05, 13, 10, 05, 00), new DateTime(2023, 05, 13, 10, 20, 00));
        }

        //قرار ملاقات با همپوشانی مواجه شده و خطا میدهد
        private void Then()
        {
            expected.Should().ThrowExactlyAsync<ThisAppointmentHasOverlap>();
        }

        [Fact]
        public void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
