using ClinicManagement.Core;
using ClinicManagement.Core.Models.Doctors;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClinicManagement.Tests.Unit.Doctrs
{
    public class DoctorUnitTests
    {
        private EFDataContext _context;

        public DoctorUnitTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
        }

        [Fact]
        public void Set_Constructor_For_Physician()
        {
            var doctorid = Guid.NewGuid();

            var physician = new Physician(doctorid, "zohre", "jojam");

            physician.Id.Should().Be(doctorid);
            physician.FirstName.Should().Be("zohre");
            physician.LastName.Should().Be("jojam");
            physician.DurationVisit.Should().Be("15");
        }

        [Fact]
        public void Set_Constructor_For_Specialist()
        {
            var doctorid = Guid.NewGuid();

            var physician = new Specialist(doctorid, "reza", "tavakoli");

            physician.Id.Should().Be(doctorid);
            physician.FirstName.Should().Be("reza");
            physician.LastName.Should().Be("tavakoli");
            physician.DurationVisit.Should().Be("30");
        }
    }
}
