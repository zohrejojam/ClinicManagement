namespace ClinicManagement.Core.Models.Doctors
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DurationVisit { get; set; }
        
        public HashSet<WeeklySchedule> WeeklySchedules { get; set; }
        public HashSet<Appointment> Appointments { get; set; }

        public Doctor(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Appointments = new HashSet<Appointment>();
            WeeklySchedules = new HashSet<WeeklySchedule>();
        }
        
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
