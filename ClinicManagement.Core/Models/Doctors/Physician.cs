namespace ClinicManagement.Core.Models.Doctors
{
    public class Physician : Doctor
    {
        public Physician(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            DurationVisit = "15";
        }

        public Doctor Doctor { get; set; }
    }
}
