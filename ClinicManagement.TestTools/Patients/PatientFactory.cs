using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.TestTools.Patients
{
    public static class PatientFactory
    {
        public static Patient GeneratePatient(int id,string name, string family)
        {
            return new Patient(id, name, family);
        }
    }
}
