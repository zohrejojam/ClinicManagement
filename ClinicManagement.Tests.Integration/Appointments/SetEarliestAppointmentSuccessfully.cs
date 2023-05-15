using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Models.Doctors;
using ClinicManagement.Services.Appointments;
using ClinicManagement.Tests.Integration.Infrastructure;
using ClinicManagement.TestTools.Appointments;
using ClinicManagement.TestTools.Doctors;
using ClinicManagement.TestTools.Patients;
using ClinicManagement.TestTools.WeeklySchedules;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClinicManagement.Tests.Integration.Appointments
{
    //ایجاد نزدیک ترین نوبت ویزیت
    public class SetEarliestAppointmentSuccessfully : EFDataContextDatabaseFixture
    {
        private EFDataContext _context;
        private EFDataContext _raedcontext;
        private IAppointmentService sut;
        private Doctor doctor;
        private Patient patient;

        public SetEarliestAppointmentSuccessfully()
        {
            //این دوخط جهت تست با دیتابیس اینمموری، کامنت شود
            //EFDataContextDatabaseFixture همچنین از این کلاس ارث بری نشود
            _context = CreateDataContext();
            _raedcontext = CreateDataContext();

            //این دوخط جهت تست با دیتابیس اینمموری، آنکامنت شود
            //var db = new EFInMemoryDatabase();
            //_context = db.CreateDataContext<EFDataContext>();
            //_raedcontext = db.CreateDataContext<EFDataContext>();
        }

        //هیچ قرار ملاقاتی برای بیمار با نام زهره جوجم تنظیم نشده است
        //یک دکتر متخصص به نام رضا توکلی در روز جاری
        //از یک ساعت بعد الی 8 ساعت بعد در درمانگاه حضور دارد
        private void Given()
        {
            sut = AppointmentFactory.CreateService(_context);
            doctor = DoctorFactory.GenerateSpecialist("reza", "tavakoli");
            var firstWeeklyScedules = new WeeklyScheduleBuilder().WithId(1)
                .WithStartDate(DateTime.Now.AddHours(1))
                .WithEndDate(DateTime.Now.AddHours(8))
                .WithDoctor(doctor.Id)
                .Build();
            doctor.WeeklySchedules.Add(firstWeeklyScedules);

            var secondWeeklyScedules = new WeeklyScheduleBuilder().WithId(2)
                .WithStartDate(DateTime.Now.AddHours(-8))
                .WithEndDate(DateTime.Now.AddHours(-1))
                .WithDoctor(doctor.Id)
                .Build();
            doctor.WeeklySchedules.Add(secondWeeklyScedules);
            _context.Doctors.Add(doctor);

            patient = PatientFactory.GeneratePatient(id: 1, "zohre", "jojam");
            _context.Set<Patient>().Add(patient);

            _context.SaveChanges();
        }

        // زمانی که درخواست نزدیکترین قرار ملاقات با دکتر توکلی برای بیمار با نام زهره جوجم ثبت میشود 
        private async Task When()
        {
            await sut.SetEarliestAppointment(doctor, patient);
        }

        //قرار ملاقات بدون هیچ تداخلی برای یک ساعت بعد در روز جاری ثبت میشود
        private void Then()
        {
            var expected = _raedcontext.Appointments.FirstOrDefault(_ => _.PatientId == patient.Id);
            expected.DoctorId.Should().Be(doctor.Id);
            expected.Start.Day.Should().Be(DateTime.Now.AddHours(1).Day);
            expected.Start.Hour.Should().Be(DateTime.Now.AddHours(1).Hour);
            expected.Start.Minute.Should().Be(DateTime.Now.AddHours(1).Minute);
            expected.End.Minute.Should().Be(DateTime.Now.AddHours(1).AddMinutes(int.Parse(doctor.DurationVisit)).Minute);
        }

        [Fact]
        public void Run()
        {
            Given();
            When().Wait();
            Then();
        }
    }
}
