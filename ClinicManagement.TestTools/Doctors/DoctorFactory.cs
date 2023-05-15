using ClinicManagement.Core.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.TestTools.Doctors
{
    public static class DoctorFactory
    {
        public static Specialist GenerateSpecialist(string doctorName,string doctorFamily)
        {
            return new Specialist(Guid.NewGuid(), doctorName, doctorFamily);

        }

        public static Physician GeneratePhysician(string doctorName, string doctorFamily)
        {
            return new Physician(Guid.NewGuid(), doctorName, doctorFamily);
        }
    }
}
