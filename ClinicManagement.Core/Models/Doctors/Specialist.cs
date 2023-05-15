namespace ClinicManagement.Core.Models.Doctors
{
    public class Specialist : Doctor
    {
        public Specialist(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            DurationVisit = "30";
        }

        public Doctor Doctor { get; set; }
        
    }
}
